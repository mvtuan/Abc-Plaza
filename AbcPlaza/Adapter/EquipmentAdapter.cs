using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbcPlaza.Api.Response;
using AbcPlaza.Listener;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AbcPlaza.Adapter
{
    public class EquipmentAdapter : RecyclerView.Adapter, IItemClickListener
    {
        public IRecycleViewOnItemClickListener recycleViewOnItemClickListener;

        public void SetRecycleViewOnItemClickListener(IRecycleViewOnItemClickListener recycleViewOnItemClickListener)
        {
            this.recycleViewOnItemClickListener = recycleViewOnItemClickListener;
        }
        public List<Equipment> data { get; set; }
        private Context mCtx;


        public EquipmentAdapter(List<Equipment> data, Context mCtx)
        {
            this.data = data;
            this.mCtx = mCtx;
        }

        public override int ItemCount
        {
            get
            {
                return data.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewHolder viewHolder = holder as ViewHolder;
            viewHolder.img_abc.SetImageResource(data[position].image);
            viewHolder.tv_abc.Text = data[position].tv_dm;
            viewHolder.tx_abc.Text = data[position].tx_dm;
            viewHolder.td_abc.Text = data[position].td_dm;

            viewHolder.buttonOptions_abc.Click += (sender, e) =>
            {
                Android.Support.V7.Widget.PopupMenu popup = new Android.Support.V7.Widget.PopupMenu(mCtx, viewHolder.buttonOptions_abc);
                popup.Inflate(Resource.Menu.popup_menu);
                popup.SetOnMenuItemClickListener(new MyOnMenuItemClickListener(this, position));
                popup.Show();
            };
            viewHolder.SetItemClickListener(this);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_equipment, parent, false);
            return new ViewHolder(view);
        }

        public void OnClick(View view, int position)
        {
            if (recycleViewOnItemClickListener != null)
            {
                recycleViewOnItemClickListener.OnClick(view, position);
            }
        }

        public void OnLongCLick(View view, int position)
        {
            if (recycleViewOnItemClickListener != null)
            {
                recycleViewOnItemClickListener.OnLongClick(view, position);
            }

        }
    }
    public class MyOnMenuItemClickListener : Java.Lang.Object, Android.Support.V7.Widget.PopupMenu.IOnMenuItemClickListener
    {
        readonly EquipmentAdapter adapter;
        private int position;

        public MyOnMenuItemClickListener(EquipmentAdapter adapter, int position)
        {
            this.adapter = adapter;
            this.position = position;
        }

        public bool OnMenuItemClick(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_delete:
                    {
                        Console.WriteLine("postion:{0}", position);
                        adapter.data.Remove(adapter.data[position]);
                        adapter.NotifyItemRemoved(position);
                        break;
                    }
            }
            return false;
        }
    }

    public class ViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
    {
        // https://www.youtube.com/watch?v=CN66PE1j7yw
        private IItemClickListener itemClickListener;

        public ImageView img_abc { get; set; }
        public TextView tv_abc { get; set; }
        public TextView tx_abc { get; set; }
        public TextView td_abc { get; set; }
        public Button buttonOptions_abc { get; set; }


        public ViewHolder(View itemView) : base(itemView)
        {
            img_abc = (ImageView)itemView.FindViewById(Resource.Id.img);
            tv_abc = (TextView)itemView.FindViewById(Resource.Id.tv);
            tx_abc = (TextView)itemView.FindViewById(Resource.Id.tx);
            td_abc = (TextView)itemView.FindViewById(Resource.Id.td);
            buttonOptions_abc = (Button)itemView.FindViewById(Resource.Id.buttonOptions);
            itemView.SetOnClickListener(this);
            itemView.SetOnLongClickListener(this);

        }

        public void SetItemClickListener(IItemClickListener itemClickListener)
        {
            this.itemClickListener = itemClickListener;
        }

        public void OnClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition);
        }

        public bool OnLongClick(View v)
        {
            itemClickListener.OnLongCLick(v, AdapterPosition);
            return true;
        }
    }
}