using final.Controllers;
using final.Models;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace ScheduledTaskExample.ScheduledTasks
{
    //job to select winning bid after X hours from group opening time
    public class WinningBidJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string groupId = dataMap.GetString("groupId");

            
            BidController bidController = new BidController();
            bidController.winningBidSelector(groupId);
        }

        public static void Start(string groupId, DateTime openingTime)
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            //passing groupId to the job
            IJobDetail job = JobBuilder.Create<WinningBidJob>()
                .UsingJobData("groupId", groupId)
                .Build();

            //setting trigger - run after X hours of openinng group
            ITrigger trigger = TriggerBuilder.Create()
                .StartAt(openingTime.AddHours(Constants.MAX_TIME_GRPUO_OFFER))
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }

    //job to deactivate group after X days from group opening time
    public class DeactivateGroupJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string groupId = dataMap.GetString("groupId");

            
            GroupController groupController = new GroupController();
            groupController.deactivateGroup(groupId);
        }

        public static void Start(string groupId, DateTime expirationDate)
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            //passing groupId to the job
            IJobDetail job = JobBuilder.Create<WinningBidJob>()
                .UsingJobData("groupId", groupId)
                .Build();

            //setting trigger - run after X days of openinng group
            ITrigger trigger = TriggerBuilder.Create()
                .StartAt(expirationDate)
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}