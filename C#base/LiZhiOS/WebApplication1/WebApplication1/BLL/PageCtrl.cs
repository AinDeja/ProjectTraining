using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1.BLL
{
    public class PageCtrl
    {
        public int pageMax(int counts)
        {
            //判断最大页数
            int pageMax;
            int pageRemainder = (counts) % 6;//每页显示多少条
            if (pageRemainder > 0)
            {
                pageMax = ((counts) / 6) + 1;
            }
            else
            {
                pageMax = (counts) / 6;
            }
            return pageMax;
        }
        public int pageMove(int pageMax,int counts,int trpage,int pageNumber){
           

            //首尾页上下页跳转判断
            if (trpage == null)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = trpage;
                if (pageNumber > pageMax)
                {
                    pageNumber = pageMax;
                }
                else
                {
                    if (pageNumber <= 0)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        pageNumber = trpage; //trpage; ;
                    }

                }

            }
            return pageNumber;
        }
         
    }
}