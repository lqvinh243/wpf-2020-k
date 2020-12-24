﻿using Doan.Business;
using Doan.Common;
using Doan.Form;
using Doan.State;
using Doan.ValueObject.OrderProductVO;
using Doan.ValueObject.OrderVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Doan.UserControls
{
    /// <summary>
    /// Interaction logic for UCSaleDashboard.xaml
    /// </summary>
    public partial class UCSaleDashboard : UserControl
    {
        private OrderBusiness orderBus = new OrderBusiness();

        bool isAction = false;
        bool isSelect = false;
        public UCSaleDashboard()
        {
            InitializeComponent();

            Loaded += UCSaleDashboard_Loaded;

            btnAddProduct.Click += BtnAddProduct_Click;
            btnDeleteProduct.Click += BtnDeleteProduct_Click;
            MainWindow.evenHandler += MainWindow_evenHandler;

            OrderHistoryLV.SelectionChanged += OrderHistoryLV_SelectionChanged;

            this.btnDone.Click += BtnDone_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnPrevius.Click += BtnPrevius_Click;
            this.btnNext.Click += BtnNext_Click;

        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            CalPagination();
            ProductState.pagination.previus = true;
            ProductState.pagination.skip += ProductState.pagination.limit;
        }

        private void BtnPrevius_Click(object sender, RoutedEventArgs e)
        {
            ProductState.pagination.next = true;
            ProductState.pagination.skip -= ProductState.pagination.limit;
            CalPagination();
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (OrderProductLV.SelectedItems.Count > 0)
            {
                var itemRm = OrderProductLV.SelectedItems[0] as OrderProductCreateVO;
                //rest of your logic
                orderAction.orderProductVOs.Remove(itemRm);
                orderAction.TotalAmount = orderAction.orderProductVOs.Select(item => item.TotalAmount).Sum();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            OrderState.Action = 1;
            ActionStatusOrder();
            orderAction.reset();
            OrderHistoryLV.SelectedIndex = -1;
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            if(orderAction.orderProductVOs.Count() <= 0)
            {
                MessageBox.Show("Đơn hàng phải có ít nhất một sản phẩm!!");
                return;
            }
           
            if (OrderState.Action == 2)
            {
                var p = orderBus.update(orderAction.Id,orderAction.toOrderUpdateVO());
            }
            else
            {
                var p = orderBus.InsertData(orderAction);
                OrderState.ordersState.Add(p);
            }
            OrderState.Action = 1;
            ActionStatusOrder();
            PaginationLoad(ActionOrder.Reload);
            orderAction.reset();
        }
           
     
        private void OrderHistoryLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderHistoryLV.SelectedIndex != -1)
            {
                var order = OrderHistoryLV.SelectedItem as Order;
                if(isAction == false)
                {
                    orderAction.PassValue(order);
                    isSelect = true;
                }    
            }
        }

        OrderCreateVO orderAction = new OrderCreateVO();
        private void UCSaleDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            OrderState.ordersState = orderBus.getAll();
            OrderState.pagination.total = OrderState.ordersState.Count;
            OrderHistoryLV.ItemsSource = OrderState.ordersState;
            OrderDetail.DataContext = orderAction;
            OrderProductLV.ItemsSource = orderAction.orderProductVOs;
            paginationOrder.DataContext = OrderState.pagination;
            CalPagination();

            ActionStatusOrder();
        }

        private void MainWindow_evenHandler(object sender, EventArgs e)
        {
            switch (sender)
            {
                case ActionOrder.Create:
                    OrderState.Action = 3;
                    ActionStatusOrder();
                    break;
                case ActionOrder.Update:
                    if (isSelect == false)
                    {
                        MessageBox.Show("Chọn đơn hàng để chỉnh sửa nha bạn!");
                        return;
                    }
                    OrderState.Action = 2;
                    ActionStatusOrder();
                    break;
                case ActionOrder.Delete:
                    OrderState.pagination.skip = 0;
                    break;
                case ActionOrder.Reload:
                    OrderState.pagination.skip = 0;
                    break;
                default: break;
            }
        }

        public static void CalPagination()
        {
            if (OrderState.pagination.skip == 0)
            {
                OrderState.pagination.previus = false;
            }
            if (OrderState.pagination.skip + OrderState.pagination.limit >= OrderState.pagination.total)
            {
                OrderState.pagination.next = false;
            }
            else OrderState.pagination.next = true;
        }

        private void ReFillList(List<Order> ord)
        {
            OrderState.ordersState.Clear();
            for (int i = 0; i < ord.Count; i++)
            {
                OrderState.ordersState.Add(ord[i]);
            }
        }

        private void PaginationLoad(ActionOrder action)
        {
            switch (action)
            {
                case ActionOrder.Reload:
                    var pagination = orderBus.getAll(OrderState.pagination.skip, OrderState.pagination.limit);
                    OrderState.pagination.total = pagination.count;
                    ReFillList(pagination.orders);
                    break;
                default:break;
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            FunctionHelper.Pagination(ActionPagination.Load, ActionProduct.Reload);
            AllProductForm frm = new AllProductForm();
            frm.ShowDialog();
            if(frm.DialogResult == true)
            {
                if(OrderState.Action == 3 || OrderState.Action == 2)
                {
                    OrderProductCreateVO ordP = new OrderProductCreateVO(frm.productSelected);
                    var ordPFind = orderAction.orderProductVOs.Where(item => item.ProductID == ordP.ProductID).FirstOrDefault();
                    if(ordPFind != null)
                    {
                        frm.quantity += ordPFind.Quantity;
                        orderAction.orderProductVOs.Remove(ordPFind);
                    }
                    ordP.Quantity = frm.quantity;
                    ordP.TotalAmount = ordP.Quantity * ordP.Amount;
                    orderAction.orderProductVOs.Add(ordP);
                    orderAction.TotalAmount = orderAction.orderProductVOs.Select(item => item.TotalAmount).Sum();
                }
            }
        }

        private void ActionStatusOrder()
        {
           
            if (OrderState.Action == 1)
            {
                this.Mode.Text = "Xem đơn hàng";
                EnableForm(0);
            }
            else if (OrderState.Action == 2)
            {
                if(isAction == true)
                {
                    var reuslt = MessageBox.Show("Bạn đang thực hiện một hành động khác, bạn muốn hủy bỏ ngay?", "Thông báo", MessageBoxButton.YesNo);
                    if (reuslt == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                this.Mode.Text = "Cập nhật đơn hàng";
                EnableForm(1);
            }
            else
            {
                if (isAction == true)
                {
                    var reuslt = MessageBox.Show("Bạn đang thực hiện một hành động khác, bạn muốn hủy bỏ ngay?", "Thông báo", MessageBoxButton.YesNo);
                    if (reuslt == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                this.Mode.Text = "Tạo đơn hàng";
                if (isAction == true)
                {
                    MessageBox.Show("Bạn đang tạo đơn hàng rồi!");
                    return;
                }
                EnableForm(1);
                OrderCreateVO orderSelected = new OrderCreateVO();
                orderAction.PassValue(orderSelected);
            }
        }

        private void EnableForm(int index)
        {
            if (index == 1)
            {
                isAction = true;
                this.btnAddProduct.IsEnabled = true;
                this.btnCancel.IsEnabled = true;
                this.btnDone.IsEnabled = true;
                this.btnDeleteProduct.IsEnabled = true;
            }
            else
            {
                isAction = false;
                this.btnAddProduct.IsEnabled = false;
                this.btnCancel.IsEnabled = false;
                this.btnDone.IsEnabled = false;
                this.btnDeleteProduct.IsEnabled = false;
            }
        }
    }
}