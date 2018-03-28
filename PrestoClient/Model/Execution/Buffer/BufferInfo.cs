﻿using System;

namespace BAMCIS.PrestoClient.Model.Execution.Buffer
{
    /// <summary>
    /// From com.facebook.execution.buffer.BufferInfo.java
    /// </summary>
    public class BufferInfo
    {
        #region Public Properties

        public OutputBufferId BufferId { get; }

        public bool Finished { get; }

        public int BufferedPages { get; }

        public long PagesSent { get; }

        public PageBufferInfo PageBufferInfo { get; }

        #endregion

        #region Constructors

        public BufferInfo(OutputBufferId bufferId, bool finished, int bufferedPages, long pagesSent, PageBufferInfo pageBufferInfo)
        {
            if (bufferedPages < 0)
            {
                throw new ArgumentOutOfRangeException("bufferedPages", "The buffered pages cannot be less than 0.");
            }

            if (pagesSent < 0)
            {
                throw new ArgumentOutOfRangeException("pagesSent", "The pages sent cannot be less than 0.");
            }

            this.BufferId = bufferId ?? throw new ArgumentNullException("bufferId");
            this.PagesSent = pagesSent;
            this.PageBufferInfo = pageBufferInfo ?? throw new ArgumentNullException("pageBufferInfo");
            this.Finished = finished;
            this.BufferedPages = bufferedPages;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"BufferInfo {{bufferId={this.BufferId}, finished={this.Finished}, bufferedPages={this.BufferedPages}, pagesSent={this.PagesSent}, pageBufferInfo={this.PageBufferInfo}}}";
        }

        #endregion
    }
}
