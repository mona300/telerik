using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Collections;

namespace AsyncData
{
    public class AsyncVM
    {
        private ObservableCollection<PlotInfo> asyncData;
        private int maxItemsCount = 1500;

        private Timer timer;
        private int randomizerCount;

        public AsyncVM()
        {
            this.asyncData = new ObservableCollection<PlotInfo>();
            this.PopulateData();

            this.timer = new Timer();
            this.timer.Interval = 50;
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.Start();
        }

        public ObservableCollection<PlotInfo> AsyncData
        {
            get
            {
                return this.asyncData;
            }
        }

        private void PopulateData()
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < this.maxItemsCount; i++)
            {
                this.asyncData.Add(new PlotInfo { Date = now.AddMilliseconds((i - this.maxItemsCount) * 50), YVal = GetNextY() });
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (((ICollection)this.asyncData).SyncRoot)
            {
                DateTime now = DateTime.Now;
                this.asyncData.Add(new PlotInfo { Date = now, YVal = this.GetNextY() });

                int count = this.asyncData.Count - this.maxItemsCount;
                for (int i = 0; i < count; i++)
                {
                    this.asyncData.RemoveAt(0);
                }
            }
        }

        private int GetNextY()
        {
            this.randomizerCount++;
            int i = this.randomizerCount;
            int y = i % 93 + i % 71 + i % 47 + i % 13 + i % 7;

            return y;
        }
    }
}
