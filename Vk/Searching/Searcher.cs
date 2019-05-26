using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vk.Comment_;
using Vk.Mapping;
using Vk.Post_;

namespace Vk.Searching
{
    class Searcher
    {
        List<PostWithComment> searchedValue;

        public async Task<Wall> Search(IEnumerable<PostWithComment> postWithComments,
            IEnumerable<string> valueToSearch, DateTime? date, CancellationToken cancellationToken)
        {
            searchedValue = new List<PostWithComment>();

            if (postWithComments != null && postWithComments.ToList().Count > 0)
            {
                await SearchPostAsync(postWithComments.ToList(), valueToSearch, date, cancellationToken);
            }

            return new ParserToWall().Parse(searchedValue, postWithComments.Count());
        }

        Task SearchPostAsync(List<PostWithComment> postWithComments, IEnumerable<string> valueToSearch,
            DateTime? date, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var post in postWithComments)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (SearchPost(valueToSearch, date, post.Post, searchedValue))
                    {
                        continue;
                    }

                    var p = new PostWithComment { Post = post.Post };

                    SearchComment(valueToSearch, date, post.Comments, p);

                    if (p.Comments.Count() > 0)
                    {
                        searchedValue.Add(p);
                    }
                }
            });
        }

        bool SearchPost(IEnumerable<string> valueToSearch, DateTime? date, Item post, List<PostWithComment> searchedValue)
        {
            if (CheckDate(post.date, date))
            {
                if (SearchValue(post.text, valueToSearch))
                {
                    searchedValue.Add(new PostWithComment
                    {
                        Post = post,                        
                    });

                    return true;
                }
            }

            return false;
        }

        void SearchComment(IEnumerable<string> valueToSearch, DateTime? date, 
            IEnumerable<ItemComment> itemComment, PostWithComment post)
        {
            if (itemComment != null && itemComment.ToList().Count > 0)
            {
                itemComment.ToList().ForEach(i => {
                    if (CheckDate(i.date, date))
                    {
                        if (SearchValue(i.text, valueToSearch))
                        {
                            var list = post.Comments.ToList();
                            list.Add(i);
                            post.Comments = list;
                        }
                    }
                });

                foreach (var item in itemComment)
                {
                    SearchComment(valueToSearch, date, item.thread.items, post);
                }
            }
        }

        bool SearchValue(string text, IEnumerable<string> valueForSearching)
        {
            if (valueForSearching == null || valueForSearching.ToList().Count == 0 || (valueForSearching.Count() == 1 && valueForSearching.First() == ""))
            {
                return true;
            }

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var listOfText = text
                .Trim()
                .Split(' ')
                .Distinct();

            foreach (var firstValue in listOfText)
            {
                foreach (var secondValue in valueForSearching)
                {
                    if (firstValue.ToLower().Contains(secondValue.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        bool CheckDate(int date, DateTime? dateToCheck)
        {
            if (dateToCheck == null)
            {
                return true;
            }

            return CompareDate(dateToCheck.Value, Helper.ConvertorDate.ConvertDateTimeFromUnix(date));
        }

        bool CompareDate(DateTime date, DateTime dateToCheck)
        {
            int yearOne = date.Year;
            int monthOne = date.Month;
            int dayOne = date.Day;

            int yearTwo = dateToCheck.Year;
            int monthTwo = dateToCheck.Month;
            int dayTwo = dateToCheck.Day;

            return 0 >= DateTime.Compare(new DateTime(yearOne, monthOne, dayOne), new DateTime(yearTwo, monthTwo, dayTwo));
        }
    }
}
