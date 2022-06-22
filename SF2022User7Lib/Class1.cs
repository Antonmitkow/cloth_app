using System;
using System.Collections.Generic;

namespace SF2022User7Lib
{
    public static class Calculations
    {
        public static string[] AvailablePeriods(
           TimeSpan[] startTimes,
             int[] durations,
              TimeSpan beginWorkingTime,
               TimeSpan endWorkingTime,
              int consultationTime
 )
        {
            //List<string> result = new List<string>();
            //TimeSpan currentTime = beginWorkingTime;
            //while (currentTime.Add(TimeSpan.FromMinutes(consultationTime)) <= endWorkingTime)
            //{
            //    bool isBusy = false;
            //    for (int i = 0; i < startTimes.Length; i++)
            //    {
            //        if (!(currentTime >= startTimes[i].Add(TimeSpan.FromMinutes(durations[i])) || startTimes[i] >= currentTime.Add(TimeSpan.FromMinutes(consultationTime))))
            //        {
            //            isBusy = true;
            //            currentTime = startTimes[i].Add(TimeSpan.FromMinutes(durations[i]));
            //            break;
            //        }
            //    }
            //    if (!isBusy)
            //    {
            //        result.Add(currentTime.ToString(@"hh\:mm") + "-" + currentTime.Add(TimeSpan.FromMinutes(consultationTime)).ToString(@"hh\:mm"));
            //        currentTime = currentTime.Add(TimeSpan.FromMinutes(consultationTime));
            //    }
            //}

            //return result.ToArray();

            List<string> result = new List<string>();
            TimeSpan currentTime = beginWorkingTime;
            while (currentTime.Add(TimeSpan.FromMinutes(consultationTime)) <= endWorkingTime)
            {
                bool isBusy = false;
                for(int i = 0; i < startTimes.Length; i++)
                {
                    if(!(currentTime >= startTimes[i].Add(TimeSpan.FromMinutes(durations[i])) || startTimes[i] >= currentTime.Add(TimeSpan.FromMinutes(consultationTime))))
                    {
                        isBusy = true;
                        currentTime = startTimes[i].Add(TimeSpan.FromMinutes(durations[i]));
                        break;
                    }
                    if(!isBusy)
                    {
                        result.Add(currentTime.ToString(@"hh\:mm") + "-" + currentTime.Add(TimeSpan.FromMinutes(consultationTime)).ToString(@"hh\:mm"));
                        currentTime = currentTime.Add(TimeSpan.FromMinutes(consultationTime));
                    }
                }
            }
            return result.ToArray();
 


            //1 - currentTime.Add(TimeSpan.FromMinutes(consultationTime))
            //2 - startTimes[i].Add(TimeSpan.FromMinutes(durations[i]))


            //List<string> result = new List<string>();
            //TimeSpan currentTime = beginWorkingTime;
            //while(----1----- <= endWorkingTime)
            //{
            //    bool isBusy = false;
            //    for(int i=0; i< startTimes.Length; i++)
            //    {
            //        if(!(currentTime >= -----2------) || startTimes[i] >= -----1------))))
            //        {
            //            isBusy = true;
            //            currentTime = ------2------);
            //            break;
            //        }
            //        if(!isBusy)
            //        {
            //            result.Add(currentTime.ToString(@"hh\:mm") + "-" + -----1------).ToString(@"hh\:mm"));
            //            currentTime = ------1------);
            //        }
            //    }
            //}
            //return result.ToArray();


        }
    }
}
