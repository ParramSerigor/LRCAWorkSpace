<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OnlineHelp.aspx.cs" Inherits="LRCA.OnlineHelp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
     <div class="normalheader small-header transition animated fadeIn">
        <div class="hpanel">
            <div class="panel-body">
                <div id="hbreadcrumb" class="pull-right">
                    <ol class="hbreadcrumb breadcrumb">
                    
                        <li>Online Help</li>
                        <li class="active">
                            <span> <asp:Label ID="lblCompanyInfo" runat="server" ></asp:Label></span>
                        </li>
                    </ol>
                </div>
                <h2 class="font-light m-b-xs">         
               Online Help
                </h2>
                <small>If you any issues with the application. Please, use the contact form below. This form will connect you to our support team 24/7. </small>
            </div>
        </div>
    </div>
     <asp:Label ID="lblerror" runat="server" ></asp:Label> 
        <br /><br />
    <div class="row">
            <div class="col-lg-9">
                <div class="hpanel">
			    
            <div class="panel-body">

    
	
                                   
                                       
                                <div class="form-group"><label class="col-sm-2 control-label">User</label>
                                        <div class="col-sm-10">
                                            <asp:Label ID="txtUser" class="form-control m-b" disabled runat="server" ></asp:Label>
										</div>
                                        </div>
                <div class="form-group"><label class="col-sm-2 control-label">Registered Email</label>
                                            <div class="col-sm-10">
                                                <asp:Label ID="txtEmail" class="form-control m-b" disabled runat="server" ></asp:Label>
                                           </div>
                                            </div>

                                        <div class="form-group"><label class="col-sm-2 control-label">Problem Related to</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="dropPType" class="form-control m-b" runat="server">
                            <asp:ListItem Value="Trainee">Trainee Module</asp:ListItem>
                            <asp:ListItem Value="Instructor Module">Instructor Module</asp:ListItem>
                            <asp:ListItem Value="Training Provider Module">Training Provider Module</asp:ListItem>
                            <asp:ListItem Value="MDE Program Module">MDE Program Module</asp:ListItem>
                            <asp:ListItem Value="Property Owner Module">Property Owner Module</asp:ListItem>
                            <asp:ListItem Value="Inspection Program Module">Inspection Program Module</asp:ListItem>
                            <asp:ListItem Value="Other">Other</asp:ListItem>
                        </asp:DropDownList>
										 </div>

                                             <div class="form-group"><label class="col-sm-2 control-label">Description</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control m-b" required></asp:TextBox>
										</div>
                                        </div>

                                              </div>
									</div>
                                              
                <div class="modal-footer" nowrap>
								<input id="Hidden1" name="Hidden1" type="Hidden" runat="server" value="" /> 
                                        
                    <button onclick="window.location.href='dashboard.aspx?Dash=active'" class="btn btn-default" alt="Back To Dashboard" title="Back To Dashboard">Back</button>
														<asp:Button ID="btnAddVideo" runat="server" Text="Submit" OnClick="btnSave"  CssClass="btn btn-primary" ToolTip="Submit" />    
											
    
                    </div>
                  </div>
                </div>	
    
         	<div class="col-lg-3">
            <div class="hpanel">
           <div></div>
                <div class="panel-body">
              <div class="control-group">
                    <div class="controls" style="text-align:center;">
                       <h1>How to use online Help?</h1>
		           <p>Online help is designed to caters any issues that you are experiencing and if you want to understand any application logic. Please, fill out the form below and send us your comments.</p>
										
        </div>
                               </div>
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
     <script src="CSSBackEnd/js/bootstrap-filestyle.js"></script>

		<script type="text/javascript">
    
// DO NOT REMOVE : GLOBAL FUNCTIONS!

		    $(document).ready(function () {

               
                 // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".openVideo", function () {
		            var myBookId = $(this).data('id');
		            document.getElementById('bookId').innerHTML = myBookId;
		        });

		        // This is where it is opening the video window in modal for viewing.
		        $(document).on("click", ".open-DeleteVideo", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Delete this Manual from the List?')) {
		                CallAjax(DeleteId);
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

            
		    function CallAjax(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "UpdateCompInfo.aspx/CallRemove",
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

