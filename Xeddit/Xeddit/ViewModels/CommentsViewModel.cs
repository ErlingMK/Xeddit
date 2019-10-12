﻿using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.DataModels.Things;
using Xeddit.Models;
using Xeddit.ViewModels.Base;
using Xeddit.ViewModels.Interfaces;

namespace Xeddit.ViewModels
{
    public class CommentsViewModel : BaseViewModel, ICommentsViewModel
    {
        private readonly ICommentsModel m_commentsModel;
        private IList<Comment> m_comments;

        public CommentsViewModel(ICommentsModel commentsModel)
        {
            m_commentsModel = commentsModel;
        }

        public async void PreloadComments(string permalink)
        {
            var comments = await m_commentsModel.GetCommentsForPostAsync(permalink);

            Comments = comments;
        }

        public ILink CurrentLink { get; set; }
        public IList<Comment> Comments
        {
            get => m_comments;
            set => SetProperty(ref m_comments, value);
        }
    }
}