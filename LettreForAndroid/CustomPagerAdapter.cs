﻿using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace LettreForAndroid
{
    public class CustomPagerAdapter : FragmentPagerAdapter
    {
        const int PAGE_COUNT = 8;
        private string[] tabTitles = { "전체", "대화", "택배", "공공기관", "인증", "카드", "스팸", "기타" };
        readonly Context context;

        public CustomPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomPagerAdapter(Context context, FragmentManager fm) : base(fm)
        {
            this.context = context;
        }

        public override int Count
        {
            get { return PAGE_COUNT; }
        }

        public override Fragment GetItem(int position)
        {
            return PageFragment.newInstance(position + 1);
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }

        public View GetTabView(int position)
        {
            // Given you have a custom layout in `res/layout/custom_tab.xml` with a TextView
            var tv = (TextView)LayoutInflater.From(context).Inflate(Resource.Layout.custom_tab, null);
            tv.Text = tabTitles[position];
            return tv;
        }
    }
}