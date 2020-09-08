<%@ Page Title="" Language="C#" MasterPageFile="~/MDE.Master" AutoEventWireup="true" CodeBehind="MDEMgmtCourses.aspx.cs" Inherits="LRCA.MDEMgmtCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="normalheader small-header transition animated fadeIn">
    <div class="hpanel">
        <div class="panel-body">
            <div id="hbreadcrumb" class="pull-right">
                <ol class="hbreadcrumb breadcrumb">
                    <li>MDE Courses</li>
                    <li class="active">
                        <span>Course Management</span>
                    </li>
                </ol>
            </div>
            <h2 class="font-light m-b-xs">         
          MDE Courses
            </h2>
            <small>This module is for MDE staff to manage Master Course Roster.</small>
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
                           CREATE COURSE
                        </a>
                    </div>
            <div class="panel-body">
                 <div class="row">
                      <div class="col-lg-3">
                        <asp:TextBox ID="txtTitle" class="form-control m-b" placeholder="Title" runat="server" required></asp:TextBox>  
                                            </div>
                          
                     <div class="col-lg-3">
                          
                                        <asp:TextBox ID="txtDesc" class="form-control m-b" placeholder="Description" runat="server" ></asp:TextBox>  
                                        </div>
                          
                          
                     <div class="col-lg-3">
                                         <asp:DropDownList ID="dropCategory" CssClass="form-control m-b" runat="server">
                                                </asp:DropDownList>
                                        </div>
                          
                          
                     <div class="col-lg-3">
                         <div class="checkbox-primary form-control m-b">
                             <asp:CheckBox ID="chkThirdPartExam" runat="server" />
                                <label for="chkThirdPartExam">
                                    3rd Party Exam
                                </label>
                            </div>
                          </div>
                </div>
                 <div class="row">
                      <div class="col-lg-3">
                        <div class="checkbox-primary form-control m-b">
                             <asp:CheckBox ID="chkPassScoreReq" runat="server" />
                                <label for="chkPassScoreReq">
                                    Passing Score Required
                                </label>
                            </div>
                               
                                            </div>
                          
                     <div class="col-lg-3">
                          
                                       <div class="checkbox-primary form-control m-b">
                             <asp:CheckBox ID="chkAttendReq" runat="server" />
                                <label for="chkAttendReq">
                                   Attendance Required
                                </label>
                            </div>
                                        </div>
                          
                          
                     <div class="col-lg-3">
                               <asp:TextBox ID="txtPassScore" class="form-control m-b" placeholder="Passing Score" runat="server" ></asp:TextBox>         
                                        </div>
                          
                          
                  
                </div>
                </div>
                    <div class="panel-footer">
                        <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClick="AddCourse_OnClick" Text="Add Course" />
                    </div>
           
        </div>
               
            </div>
            <br />
    <div class="col-lg-12">
                <div class="hpanel">
                    
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           SYSTEM USERS
                        </a>
                    </div>
                    
                    <!-- Start of table -->
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Title </th>
													<th>Category Type</th>
                                                    <th>Valid for</th>
                                                    <th>3rd Party Exam</th>
                                                    <th>Pass-Score Req</th>
													<th>Pass-Score</th>
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

<!-- Add Video modal -->
    


<!-- View Video modal -->
<div class="modal fade" id="modalVideo"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
									×
								</button>
								<h4 id="H1" class="modal-title">Video</h4>
							</div>
							<div class="modal-body">
                                <div id="bookId" align="center"></div>
                                
							</div>
							<div class="modal-footer">
								<button data-dismiss="modal" class="btn btn-xs btn-default" type="button">
									Cancel
								</button>
								
							</div>
						</div><!-- /.modal-content -->
					</div><!-- /.modal-dialog -->
				</div>

<!-- View Video modal -->
<div class="modal fade" id="modalDelete"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<button aria-hidden="true" data-dismiss="modal" class="close" type="button">
									×
								</button>
								<h4 id="H2" class="modal-title">Deactivate Role for this User</h4>
							</div>
							<div class="modal-body">
                               <div class="alert alert-danger alert-block">
								<h4 class="alert-heading">You are about to Deactivate this Role. Press Delete to Continue</h4>
							</div>
                                
							</div>
							
						</div><!-- /.modal-content -->
                        <div class="modal-footer">
								<button data-dismiss="modal" class="btn btn-xs btn-default" type="button">	Cancel </button>&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" />
								
							</div>
					</div><!-- /.modal-dialog -->
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
            
            function CallAjaxActiveAcct(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "Ad_Users_Mgmt.aspx/CallMgmtAcct",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
		    }

		    function CallAjax(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "Ad_MDE_Mgmt.aspx/CallMgmtRole",
		            data: "{\"cgi\":\"" + cgi + "\"}",
		            contentType: "application/json",
		            dataType: "json",
		            success: function (msg) {
		                document.location.href = msg.d;
		            }
		        });
		    }
           
		</script>
    
</asp:Content>
