#define USE_EF
//#define TEST_MODEL
//#define RETRIEVE_FIELDS
//#define USE_ORDER
#define USE_ASYNC_MODE
#define USE_DEMO_FIELDS

using System;
using System.Windows.Forms;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using TestPivotGridWithServerMode.Models;

namespace TestPivotGridWithServerMode
{
    public partial class MainForm : XtraForm
    {
        readonly PivotGridDemoDBContext _db;

        public MainForm()
        {
            InitializeComponent();

            pivotGridControl.FieldsCustomization(splitContainerControl.Panel2);
            pivotGridControl.BeginRefresh += pivotGridControl_BeginRefresh;
            pivotGridControl.EndRefresh += pivotGridControl_EndRefresh;
            pivotGridControl.GridLayout += pivotGridControl_GridLayout;

            #if USE_ASYNC_MODE
                pivotGridControl.OptionsBehavior.UseAsyncMode = true;
                pivotGridControl.AsyncOperationStarting += pivotGridControl_AsyncOperationStarting;
                pivotGridControl.AsyncOperationCompleted += pivotGridControl_AsyncOperationCompleted;
            #else
                btnRefreshAsync.Visible = false;
            #endif

            _db = new PivotGridDemoDBContext();

            AddFields();

            #if USE_ASYNC_MODE
                pivotGridControl.SetDataSourceAsync(
            #else
                pivotGridControl.DataSource =
            #endif
                #if !USE_EF
                    new LinqServerModeSource
                #else
                    new EntityServerModeSource
                #endif
                    {
                        KeyExpression = "OID",
                        QueryableSource =
                            #if USE_ORDER
                                _db.Orders
                            #else
                                _db.Sales
                            #endif
                    }
                #if USE_ASYNC_MODE
                    , SetDataSourceAsyncCompletedHandler)
                #endif
                ;

            #if !USE_EF
                ((LinqServerModeSource)pivotGridControl.DataSource).ExceptionThrown += DataSourceExceptionThrown;
                ((LinqServerModeSource)pivotGridControl.DataSource).InconsistencyDetected += DataSourceInconsistencyDetected;
            #else
                ((EntityServerModeSource)pivotGridControl.DataSource).ExceptionThrown += DataSourceExceptionThrown;
                ((EntityServerModeSource)pivotGridControl.DataSource).InconsistencyDetected += DataSourceInconsistencyDetected;
            #endif

            #if RETRIEVE_FIELDS && !USE_ASYNC_MODE
                pivotGridControl.RetrieveFields();

                foreach (PivotGridField field  in pivotGridControl.Fields)
                {
                    var tmpString = string.Format("FieldName: \"{0}\", Name: \"{1}\", Caption: \"{2}\", DisplayFolder: \"{3}\", Area: \"{4}\", AreaIndex: {5}", field.FieldName, field.Name, field.Caption, field.DisplayFolder, field.Area, field.AreaIndex);

                    System.Diagnostics.Debug.WriteLine(tmpString);
                }
            #endif

/*
FieldName: "Customer.CustomerName", Name: "fieldCustomerCustomerName", Caption: "CustomerName", DisplayFolder: "Customer", Area: "FilterArea", AreaIndex: 0
FieldName: "Customer.GCRecord", Name: "fieldCustomerGCRecord", Caption: "GCRecord", DisplayFolder: "Customer", Area: "FilterArea", AreaIndex: 1
FieldName: "Customer.OID", Name: "fieldCustomerOID", Caption: "OID", DisplayFolder: "Customer", Area: "FilterArea", AreaIndex: 2
FieldName: "Customer.OptimisticLockField", Name: "fieldCustomerOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Customer", Area: "FilterArea", AreaIndex: 3
FieldName: "GCRecord", Name: "fieldGCRecord", Caption: "GCRecord", DisplayFolder: "", Area: "FilterArea", AreaIndex: 4
FieldName: "IdCustomer", Name: "fieldIdCustomer", Caption: "IdCustomer", DisplayFolder: "", Area: "FilterArea", AreaIndex: 5
FieldName: "IdSalesPerson", Name: "fieldIdSalesPerson", Caption: "IdSalesPerson", DisplayFolder: "", Area: "FilterArea", AreaIndex: 6
FieldName: "OID", Name: "fieldOID", Caption: "OID", DisplayFolder: "", Area: "FilterArea", AreaIndex: 7
FieldName: "OptimisticLockField", Name: "fieldOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "", Area: "FilterArea", AreaIndex: 8
FieldName: "OrderDate", Name: "fieldOrderDate", Caption: "OrderDate", DisplayFolder: "", Area: "FilterArea", AreaIndex: 9
FieldName: "SalesPeople.GCRecord", Name: "fieldSalesPeopleGCRecord", Caption: "GCRecord", DisplayFolder: "SalesPeople", Area: "FilterArea", AreaIndex: 10
FieldName: "SalesPeople.OID", Name: "fieldSalesPeopleOID", Caption: "OID", DisplayFolder: "SalesPeople", Area: "FilterArea", AreaIndex: 11
FieldName: "SalesPeople.OptimisticLockField", Name: "fieldSalesPeopleOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "SalesPeople", Area: "FilterArea", AreaIndex: 12
FieldName: "SalesPeople.SalesPersonName", Name: "fieldSalesPeopleSalesPersonName", Caption: "SalesPersonName", DisplayFolder: "SalesPeople", Area: "FilterArea", AreaIndex: 13

FieldName: "GCRecord", Name: "fieldGCRecord", Caption: "GCRecord", DisplayFolder: "", Area: "FilterArea", AreaIndex: 0
FieldName: "IdOrder", Name: "fieldIdOrder", Caption: "IdOrder", DisplayFolder: "", Area: "FilterArea", AreaIndex: 1
FieldName: "IdProduct", Name: "fieldIdProduct", Caption: "IdProduct", DisplayFolder: "", Area: "FilterArea", AreaIndex: 2
FieldName: "OID", Name: "fieldOID", Caption: "OID", DisplayFolder: "", Area: "FilterArea", AreaIndex: 3
FieldName: "OptimisticLockField", Name: "fieldOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "", Area: "FilterArea", AreaIndex: 4
FieldName: "Order.Customer.CustomerName", Name: "fieldOrderCustomerCustomerName", Caption: "CustomerName", DisplayFolder: "Order\Customer", Area: "FilterArea", AreaIndex: 5
FieldName: "Order.Customer.GCRecord", Name: "fieldOrderCustomerGCRecord", Caption: "GCRecord", DisplayFolder: "Order\Customer", Area: "FilterArea", AreaIndex: 6
FieldName: "Order.Customer.OID", Name: "fieldOrderCustomerOID", Caption: "OID", DisplayFolder: "Order\Customer", Area: "FilterArea", AreaIndex: 7
FieldName: "Order.Customer.OptimisticLockField", Name: "fieldOrderCustomerOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Order\Customer", Area: "FilterArea", AreaIndex: 8
FieldName: "Order.GCRecord", Name: "fieldOrderGCRecord", Caption: "GCRecord", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 9
FieldName: "Order.IdCustomer", Name: "fieldOrderIdCustomer", Caption: "IdCustomer", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 10
FieldName: "Order.IdSalesPerson", Name: "fieldOrderIdSalesPerson", Caption: "IdSalesPerson", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 11
FieldName: "Order.OID", Name: "fieldOrderOID", Caption: "OID", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 12
FieldName: "Order.OptimisticLockField", Name: "fieldOrderOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 13
FieldName: "Order.OrderDate", Name: "fieldOrderOrderDate", Caption: "OrderDate", DisplayFolder: "Order", Area: "FilterArea", AreaIndex: 14
FieldName: "Order.SalesPeople.GCRecord", Name: "fieldOrderSalesPeopleGCRecord", Caption: "GCRecord", DisplayFolder: "Order\SalesPeople", Area: "FilterArea", AreaIndex: 15
FieldName: "Order.SalesPeople.OID", Name: "fieldOrderSalesPeopleOID", Caption: "OID", DisplayFolder: "Order\SalesPeople", Area: "FilterArea", AreaIndex: 16
FieldName: "Order.SalesPeople.OptimisticLockField", Name: "fieldOrderSalesPeopleOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Order\SalesPeople", Area: "FilterArea", AreaIndex: 17
FieldName: "Order.SalesPeople.SalesPersonName", Name: "fieldOrderSalesPeopleSalesPersonName", Caption: "SalesPersonName", DisplayFolder: "Order\SalesPeople", Area: "FilterArea", AreaIndex: 18
FieldName: "Product.Category.CategoryName", Name: "fieldProductCategoryCategoryName", Caption: "CategoryName", DisplayFolder: "Product\Category", Area: "FilterArea", AreaIndex: 19
FieldName: "Product.Category.GCRecord", Name: "fieldProductCategoryGCRecord", Caption: "GCRecord", DisplayFolder: "Product\Category", Area: "FilterArea", AreaIndex: 20
FieldName: "Product.Category.OID", Name: "fieldProductCategoryOID", Caption: "OID", DisplayFolder: "Product\Category", Area: "FilterArea", AreaIndex: 21
FieldName: "Product.Category.OptimisticLockField", Name: "fieldProductCategoryOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Product\Category", Area: "FilterArea", AreaIndex: 22
FieldName: "Product.GCRecord", Name: "fieldProductGCRecord", Caption: "GCRecord", DisplayFolder: "Product", Area: "FilterArea", AreaIndex: 23
FieldName: "Product.IdCategory", Name: "fieldProductIdCategory", Caption: "IdCategory", DisplayFolder: "Product", Area: "FilterArea", AreaIndex: 24
FieldName: "Product.OID", Name: "fieldProductOID", Caption: "OID", DisplayFolder: "Product", Area: "FilterArea", AreaIndex: 25
FieldName: "Product.OptimisticLockField", Name: "fieldProductOptimisticLockField", Caption: "OptimisticLockField", DisplayFolder: "Product", Area: "FilterArea", AreaIndex: 26
FieldName: "Product.ProductName", Name: "fieldProductProductName", Caption: "ProductName", DisplayFolder: "Product", Area: "FilterArea", AreaIndex: 27
FieldName: "Quantity", Name: "fieldQuantity", Caption: "Quantity", DisplayFolder: "", Area: "FilterArea", AreaIndex: 28
FieldName: "UnitPrice", Name: "fieldUnitPrice", Caption: "UnitPrice", DisplayFolder: "", Area: "FilterArea", AreaIndex: 29
*/

            #if TEST_MODEL
                var order = _db.Orders.Find(1);

                if (order != null)
                {
                    var tmpString = string.Format("Customer: \"{0}\", SalesPerson: \"{1}\" (has {2} orders)", order.Customer.CustomerName, order.SalesPeople.SalesPersonName, order.SalesPeople.Orders.Count);
                }

                var sales = _db.Sales.Where(s => s.Order.OID == 58);

                foreach (var sale in sales)
                {
                    var tmpString = string.Format("Product: \"{0}\", Category: \"{1}\"", sale.Product.ProductName, sale.Product.Category.CategoryName);
                }

                if (_db.Sales.Count(s => s.Order.OID == 58 && s.Product.OID == 2) == 0)
                {
                    var sale = new Sale();

                    sale.Product = _db.Products.Find(2);
                    sale.Order = _db.Orders.Find(58);
                    sale.Quantity = 48;
                    sale.UnitPrice = 96.9049m;
                    sale.OptimisticLockField = 0;

                    _db.Sales.Add(sale);
                    _db.SaveChanges();
                }
            #endif
        }

        void DataSourceInconsistencyDetected(object sender, LinqServerModeInconsistencyDetectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DataSourceInconsistencyDetected");
        }

        void DataSourceExceptionThrown(object sender, LinqServerModeExceptionThrownEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DataSourceExceptionThrown");
        }

        void AddFields()
        {
            #if !RETRIEVE_FIELDS
                #if USE_ORDER
                    pivotGridControl.Fields.Add(new PivotGridField { FieldName = "OID", Name = "fieldOID", Caption = "OID", Area = PivotArea.RowArea });
                    pivotGridControl.Fields.Add(new PivotGridField { FieldName = "SalesPeople.SalesPersonName", Name = "fieldSalesPeopleSalesPersonName", Caption = "SalesPersonName", DisplayFolder = "SalesPeople", Area = PivotArea.RowArea });
                    pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Customer.CustomerName", Name = "fieldCustomerCustomerName", Caption = "CustomerName", DisplayFolder = "Customer", Area = PivotArea.RowArea });
                    pivotGridControl.Fields.Add(new PivotGridField { FieldName = "OrderDate", Name = "fieldOrderDate", Caption = "fieldOrderDate", Area = PivotArea.RowArea });
                #else
                    #if !USE_DEMO_FIELDS
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "OID", Name = "fieldOID", Caption = "OID", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "IdOrder", Name = "fieldIdOrder", Caption = "Order", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Order.OrderDate", Name = "fieldOrderOrderDate", Caption = "OrderDate", DisplayFolder = "Order", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Product.ProductName", Name = "fieldProductProductName", Caption = "ProductName", DisplayFolder = "Product", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Product.Category.CategoryName", Name = "fieldProductCategoryCategoryName", Caption = "CategoryName", DisplayFolder = "Product\\Category", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Order.SalesPeople.SalesPersonName", Name = "fieldOrderSalesPeopleSalesPersonName", Caption = "SalesPersonName", DisplayFolder = "Order\\SalesPeople", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Order.Customer.CustomerName", Name = "fieldOrderCustomerCustomerName", Caption = "CustomerName", DisplayFolder = "Order\\Customer", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "Quantity", Name = "fieldQuantity", Caption = "Quantity", Area = PivotArea.RowArea });
                        pivotGridControl.Fields.Add(new PivotGridField { FieldName = "UnitPrice", Name = "fieldUnitPrice", Caption = "UnitPrice", Area = PivotArea.RowArea });
                    #else
                        PivotGridField
                            fieldCategoryName = new PivotGridField(),
                            fieldCategoryID = new PivotGridField(),
                            fieldCustomerName = new PivotGridField(),
                            fieldCustomerID = new PivotGridField(),
                            fieldOrderID = new PivotGridField(),
                            fieldOrderDateYear = new PivotGridField(),
                            fieldOrderQuerter = new PivotGridField(),
                            fieldOrderDateMonth = new PivotGridField(),
                            fieldOrderDate = new PivotGridField(),
                            fieldProductName = new PivotGridField(),
                            fieldProductID = new PivotGridField(),
                            fieldSalesPersonName = new PivotGridField(),
                            fieldSalesPersonID = new PivotGridField(),
                            fieldUnitPrice = new PivotGridField(),
                            fieldQuantity = new PivotGridField(),
                            fieldRevenue = new PivotGridField();

                        pivotGridControl.Fields.AddRange(new[] {
                            fieldCategoryName,
                            fieldCategoryID,
                            fieldCustomerName,
                            fieldCustomerID,
                            fieldOrderID,
                            fieldOrderDateYear,
                            fieldOrderQuerter,
                            fieldOrderDateMonth,
                            fieldOrderDate,
                            fieldProductName,
                            fieldProductID,
                            fieldSalesPersonName,
                            fieldSalesPersonID,
                            fieldUnitPrice,
                            fieldQuantity,
                            fieldRevenue});

                        // 
                        // fieldOrderDateYear
                        // 
                        fieldOrderDateYear.Area = PivotArea.ColumnArea;
                        fieldOrderDateYear.AreaIndex = 0;
                        fieldOrderDateYear.Caption = "Order Year";
                        fieldOrderDateYear.DisplayFolder = "Order Date";
                        fieldOrderDateYear.FieldName = "Order.OrderDate";
                        fieldOrderDateYear.GroupInterval = PivotGroupInterval.DateYear;
                        fieldOrderDateYear.Name = "fieldOrderDateYear";
                        fieldOrderDateYear.Options.AllowRunTimeSummaryChange = true;
                        fieldOrderDateYear.UnboundFieldName = "fieldOrderDateYear";
                        // 
                        // fieldOrderDateMonth
                        // 
                        fieldOrderDateMonth.Area = PivotArea.ColumnArea;
                        fieldOrderDateMonth.AreaIndex = 1;
                        fieldOrderDateMonth.Caption = "Order Month";
                        fieldOrderDateMonth.DisplayFolder = "Order Date";
                        fieldOrderDateMonth.FieldName = "Order.OrderDate";
                        fieldOrderDateMonth.GroupInterval = PivotGroupInterval.DateMonth;
                        fieldOrderDateMonth.Name = "fieldOrderDateMonth";
                        fieldOrderDateMonth.Options.AllowRunTimeSummaryChange = true;
                        fieldOrderDateMonth.UnboundFieldName = "fieldOrderDateMonth";
                        fieldOrderDateMonth.Visible = false;
                        // 
                        // fieldCategoryName
                        // 
                        fieldCategoryName.Area = PivotArea.RowArea;
                        fieldCategoryName.AreaIndex = 1;
                        fieldCategoryName.Caption = "Category";
                        fieldCategoryName.DisplayFolder = "Product";
                        fieldCategoryName.FieldName = "Product.Category.CategoryName";
                        fieldCategoryName.Name = "fieldCategoryName";
                        fieldCategoryName.Options.AllowRunTimeSummaryChange = true;
                        fieldCategoryName.Visible = false;
                        // 
                        // fieldCategoryID
                        // 
                        fieldCategoryID.Area = PivotArea.ColumnArea;
                        fieldCategoryID.AreaIndex = 0;
                        fieldCategoryID.Caption = "CategoryID";
                        fieldCategoryID.DisplayFolder = "Product";
                        fieldCategoryID.FieldName = "Product.IdCategory";
                        fieldCategoryID.Name = "fieldCategoryID";
                        fieldCategoryID.Options.AllowRunTimeSummaryChange = true;
                        fieldCategoryID.Visible = false;
                        // 
                        // fieldCustomerName
                        // 
                        fieldCustomerName.Area = PivotArea.ColumnArea;
                        fieldCustomerName.AreaIndex = 0;
                        fieldCustomerName.Caption = "Customer";
                        fieldCustomerName.DisplayFolder = "Customer";
                        fieldCustomerName.FieldName = "Order.Customer.CustomerName";
                        fieldCustomerName.Name = "fieldCustomerName";
                        fieldCustomerName.Options.AllowRunTimeSummaryChange = true;
                        fieldCustomerName.Visible = false;
                        // 
                        // fieldCustomerID
                        // 
                        fieldCustomerID.Area = PivotArea.ColumnArea;
                        fieldCustomerID.AreaIndex = 0;
                        fieldCustomerID.Caption = "CustomerID";
                        fieldCustomerID.DisplayFolder = "Customer";
                        fieldCustomerID.FieldName = "Order.IdCustomer";
                        fieldCustomerID.Name = "fieldCustomerID";
                        fieldCustomerID.Options.AllowRunTimeSummaryChange = true;
                        fieldCustomerID.Visible = false;
                        // 
                        // fieldOrderID
                        // 
                        fieldOrderID.Area = PivotArea.ColumnArea;
                        fieldOrderID.AreaIndex = 0;
                        fieldOrderID.Caption = "OrderID";
                        fieldOrderID.DisplayFolder = "Order";
                        fieldOrderID.FieldName = "IdOrder";
                        fieldOrderID.Name = "fieldOrderID";
                        fieldOrderID.Options.AllowRunTimeSummaryChange = true;
                        fieldOrderID.Visible = false;
                        // 
                        // fieldOrderQuerter
                        // 
                        fieldOrderQuerter.AreaIndex = 0;
                        fieldOrderQuerter.Caption = "Order Querter";
                        fieldOrderQuerter.DisplayFolder = "Order Date";
                        fieldOrderQuerter.FieldName = "Order.OrderDate";
                        fieldOrderQuerter.GroupInterval = PivotGroupInterval.DateQuarter;
                        fieldOrderQuerter.Name = "fieldOrderQuerter";
                        fieldOrderQuerter.UnboundFieldName = "fieldOrderQuerter";
                        fieldOrderQuerter.Visible = false;
                        // 
                        // fieldOrderDate
                        // 
                        fieldOrderDate.Area = PivotArea.ColumnArea;
                        fieldOrderDate.AreaIndex = 0;
                        fieldOrderDate.Caption = "Order Date";
                        fieldOrderDate.DisplayFolder = "Order Date";
                        fieldOrderDate.FieldName = "Order.OrderDate";
                        fieldOrderDate.Name = "fieldOrderDate";
                        fieldOrderDate.Options.AllowRunTimeSummaryChange = true;
                        fieldOrderDate.Visible = false;
                        // 
                        // fieldProductName
                        // 
                        fieldProductName.Area = PivotArea.RowArea;
                        fieldProductName.AreaIndex = 0;
                        fieldProductName.Caption = "Product";
                        fieldProductName.DisplayFolder = "Product";
                        fieldProductName.FieldName = "Product.ProductName";
                        fieldProductName.Name = "fieldProductName";
                        fieldProductName.Options.AllowRunTimeSummaryChange = true;
                        // 
                        // fieldProductID
                        // 
                        fieldProductID.Area = PivotArea.ColumnArea;
                        fieldProductID.AreaIndex = 0;
                        fieldProductID.Caption = "ProductID";
                        fieldProductID.DisplayFolder = "Product";
                        fieldProductID.FieldName = "ProductID";
                        fieldProductID.Name = "fieldProductID";
                        fieldProductID.Options.AllowRunTimeSummaryChange = true;
                        fieldProductID.Visible = false;
                        // 
                        // fieldSalesPersonName
                        // 
                        fieldSalesPersonName.Area = PivotArea.RowArea;
                        fieldSalesPersonName.AreaIndex = 1;
                        fieldSalesPersonName.Caption = "Sales Person";
                        fieldSalesPersonName.DisplayFolder = "Sales Person";
                        fieldSalesPersonName.FieldName = "Order.SalesPeople.SalesPersonName";
                        fieldSalesPersonName.Name = "fieldSalesPersonName";
                        fieldSalesPersonName.Options.AllowRunTimeSummaryChange = true;
                        // 
                        // fieldSalesPersonID
                        // 
                        fieldSalesPersonID.Area = PivotArea.ColumnArea;
                        fieldSalesPersonID.AreaIndex = 0;
                        fieldSalesPersonID.Caption = "SalesPersonID";
                        fieldSalesPersonID.DisplayFolder = "Sales Person";
                        fieldSalesPersonID.FieldName = "Order.IdSalesPerson";
                        fieldSalesPersonID.Name = "fieldSalesPersonID";
                        fieldSalesPersonID.Options.AllowRunTimeSummaryChange = true;
                        fieldSalesPersonID.Visible = false;
                        // 
                        // fieldUnitPrice
                        // 
                        fieldUnitPrice.Area = PivotArea.DataArea;
                        fieldUnitPrice.AreaIndex = 1;
                        fieldUnitPrice.Caption = "UnitPrice";
                        fieldUnitPrice.DisplayFolder = "Order";
                        fieldUnitPrice.FieldName = "UnitPrice";
                        fieldUnitPrice.Name = "fieldUnitPrice";
                        fieldUnitPrice.Options.AllowRunTimeSummaryChange = true;
                        // 
                        // fieldQuantity
                        // 
                        fieldQuantity.Area = PivotArea.DataArea;
                        fieldQuantity.AreaIndex = 0;
                        fieldQuantity.Caption = "Quantity";
                        fieldQuantity.DisplayFolder = "Order";
                        fieldQuantity.FieldName = "Quantity";
                        fieldQuantity.Name = "fieldQuantity";
                        fieldQuantity.Options.AllowRunTimeSummaryChange = true;
                        // 
                        // fieldRevenue
                        // 
                        fieldRevenue.Area = PivotArea.DataArea;
                        fieldRevenue.AreaIndex = 2;
                        fieldRevenue.Caption = "Revenue";
                        fieldRevenue.DisplayFolder = "Order";
                        fieldRevenue.Name = "fieldRevenue";
                        fieldRevenue.UnboundExpression = "[UnitPrice]*[Quantity]";
                        fieldRevenue.UnboundFieldName = "fieldRevenue";
                        fieldRevenue.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                    #endif
                #endif
            #endif
        }

        void pivotGridControl_GridLayout(object sender, EventArgs e)
        {
            if (sender == null)
                return;
        }

        void pivotGridControl_EndRefresh(object sender, EventArgs e)
        {
            if (sender == null)
                return;
        }

        void pivotGridControl_BeginRefresh(object sender, EventArgs e)
        {
            if (sender == null)
                return;
        }

        #if USE_ASYNC_MODE
            void SetDataSourceAsyncCompletedHandler(AsyncOperationResult result)
            {
                if (result == null)
                    return;
            }

            void pivotGridControl_AsyncOperationStarting(object sender, EventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("AsyncOperationStarting");
            }

            void pivotGridControl_AsyncOperationCompleted(object sender, EventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("AsyncOperationCompleted");
            }
        #endif

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_db != null)
                _db.Dispose();
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            SimpleButton btn;

            if ((btn = sender as SimpleButton) == null)
                return;

            #if USE_ASYNC_MODE
                if (btn.Tag != null && btn.Tag.ToString() == "async")
                    pivotGridControl.RefreshDataAsync(SetDataSourceAsyncCompletedHandler);
                else
            #endif
                    pivotGridControl.RefreshData();
        }
    }
}
