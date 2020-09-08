<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="MDE_SuperApprApps.aspx.cs" Inherits="LRCA.MDE_SuperApprApps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="normalheader small-header transition animated fadeIn">
    <div class="hpanel">
        <div class="panel-body">
            <div id="hbreadcrumb" class="pull-right">
                <ol class="hbreadcrumb breadcrumb">
                    <li>MDE</li>
                    <li class="active">
                        <span>Approved/Rejected Supervisor Accreditations Applications</span>
                    </li>
                </ol>
            </div>
            <h2 class="font-light m-b-xs">         
          Supervisor Accreditations Closed Applications
            </h2>
            <small>This module is for MDE staff to manage Approved/Denied Supervisor Accreditations applications.</small>
        </div>
    </div>
</div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
    <br /><br />
        <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">
                    
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Approved Supervisor Accreditations Applications
                        </a>
                    </div>
                    
                    <!-- Start of table -->
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Company Name </th>
													<th>Category</th>
                                                    <th>Contact Name</th>
                                                    <th>Phone</th>
                                                    <th>Date Created</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlVideos" runat="server"></asp:Panel>
											</tbody>
										</table>
                </div>
        </div>
    </div>     
        </div>

    <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">
                    
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Rejected Supervisor Accreditations Applications
                        </a>
                    </div>
                    
                    <!-- Start of table -->
                              <div class="panel-body">
                                 <table id="example2" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Company Name </th>
													<th>Category</th>
                                                    <th>Contact Name</th>
                                                    <th>Phone</th>
                                                    <th>Date Created</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlDisapproved" runat="server"></asp:Panel>
											</tbody>
										</table>
                </div>
        </div>
    </div>     
        </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
    <script src="CSSBackEnd/js/plugin/datatables/jquery.dataTables-cust.min.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/ColReorder.min.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/FixedColumns.min.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/ColVis.min.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/ZeroClipboard.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/media/js/TableTools.min.js"></script>
		<script src="CSSBackEnd/js/plugin/datatables/DT_bootstrap.js"></script>
		<script src="CSSBackEnd/js/plugin/bootstrap-tags/bootstrap-tagsinput.min.js"></script>

		<script type="text/javascript">

		    // DO NOT REMOVE : GLOBAL FUNCTIONS!

		    $(document).ready(function () {

                 // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".openVideo", function () {
		            var myBookId = $(this).data('id');
		            document.getElementById('bookId').innerHTML = myBookId;
		        });

		        // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".open-DeleteVideoOff", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Deactivate this Role?')) {
		                CallAjax(DeleteId);
		            }
                });

                $(document).on("click", ".open-DeleteVideoOn", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Activate this Role?')) {
		                CallAjax(DeleteId);
		            }
                });

                 // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".open-ActivateAcctOff", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Deactivate this User Account?')) {
		                CallAjaxActiveAcct(DeleteId);
		            }
                });

                  // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".open-ActivateAcctOn", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Activate this User Account?')) {
		                CallAjaxActiveAcct(DeleteId);
		            }
		        });


		        $('#dt_basic').dataTable({
		            "sPaginationType": "bootstrap_full"
		        });

		        /* END BASIC */

		        /* Add the events etc before DataTables hides a column */
		        $("#datatable_fixed_column thead input").keyup(function () {
		            oTable.fnFilter(this.value, oTable.oApi._fnVisibleToColumnIndex(oTable.fnSettings(), $("thead input").index(this)));
		        });

		        $("#datatable_fixed_column thead input").each(function (i) {
		            this.initVal = this.value;
		        });
		        $("#datatable_fixed_column thead input").focus(function () {
		            if (this.className == "search_init") {
		                this.className = "";
		                this.value = "";
		            }
		        });
		        $("#datatable_fixed_column thead input").blur(function (i) {
		            if (this.value == "") {
		                this.className = "search_init";
		                this.value = this.initVal;
		            }
		        });


		        var oTable = $('#datatable_fixed_column').dataTable({
		            "sDom": "<'dt-top-row'><'dt-wrapper't><'dt-row dt-bottom-row'<'row'<'col-sm-6'i><'col-sm-6 text-right'p>>",
		            //"sDom" : "t<'row dt-wrapper'<'col-sm-6'i><'dt-row dt-bottom-row'<'row'<'col-sm-6'i><'col-sm-6 text-right'>>",
		            "oLanguage": {
		                "sSearch": "Search all columns:"
		            },
		            "bSortCellsTop": true
		        });
                
		        $('#datatable_col_reorder').dataTable({
		            "sPaginationType": "bootstrap",
		            "sDom": "R<'dt-top-row'Clf>r<'dt-wrapper't><'dt-row dt-bottom-row'<'row'<'col-sm-6'i><'col-sm-6 text-right'p>>",
		            "fnInitComplete": function (oSettings, json) {
		                $('.ColVis_Button').addClass('btn btn-default btn-sm').html('Columns <i class="icon-arrow-down"></i>');
		            }
		        });

		        /* END COL ORDER */

		        /* TABLE TOOLS */
		        $('#datatable_tabletools').dataTable({
		            "sDom": "<'dt-top-row'Tlf>r<'dt-wrapper't><'dt-row dt-bottom-row'<'row'<'col-sm-6'i><'col-sm-6 text-right'p>>",
		            "oTableTools": {
		                "aButtons": ["copy", "print", {
		                    "sExtends": "collection",
		                    "sButtonText": 'Save <span class="caret" />',
		                    "aButtons": ["csv", "xls", "pdf"]
		                }],
		                "sSwfPath": "CSSBackEnd/js/plugin/datatables/media/swf/copy_csv_xls_pdf.swf"
		            },
		            "fnInitComplete": function (oSettings, json) {
		                $(this).closest('#dt_table_tools_wrapper').find('.DTTT.btn-group').addClass('table_tools_group').children('a.btn').each(function () {
		                    $(this).addClass('btn-sm btn-default');
		                });
		            }
		        });
		    })
            
         
		</script>
    
</asp:Content>
