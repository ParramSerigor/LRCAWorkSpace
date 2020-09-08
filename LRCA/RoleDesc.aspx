<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RoleDesc.aspx.cs" Inherits="LRCA.RoleDesc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="normalheader small-header transition animated fadeIn">
    <div class="content">

        <div class="row">
            <div class="col-md-12">
                <div class="hpanel">
                    <div class="panel-body">
                        <h1 class="text-uppercase" style="color:#AB1027"><i class='<%=RoleIcon %>' fa-6x'></i> <%=RoleTitle %></h1>
                        <p class="lead" style="font-size:15px">
                            <%=RoleText %>
                        </p>
                    </div>
                    <asp:Panel ID="pnlLogicalButtons" runat="server"></asp:Panel>
                </div>
                
            </div>
        </div>
        <br />

        <asp:PlaceHolder ID="phInstructors" runat="server">
             <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           Instructors
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example2" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>First Name </th>
                                                    <th>Last Name</th>
                                                    <th>Email</th>
                                                    <th>Phone/Mobile</th>
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
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phGeneral" runat="server">
            <div class="row">
         <div class="col-lg-12">
            <div class="hpanel">
                <div class="panel-heading">
                    <div class="panel-tools">
                       
                    </div>
                    <h5 class="text-uppercase"><asp:Label ID="lblLowerTableHead" runat="server" Text="Label"></asp:Label> </h5>
                </div>
                <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                                            <thead>
												<tr>
													<th width="60%">Titles </th>
													<th width="20%">Status</th>
                                                    <th width="10%"></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlAppList" runat="server"></asp:Panel>
											</tbody>
										</table>
                </div>
            </div>
        </div>   
        <!-- <div class="col-lg-4">
            <div class="hpanel">
                <div class="panel-heading">
                    <div class="panel-tools">
                      
                    </div>
                    <h5 class="text-uppercase">Who needs to sign-up for <%=RoleTitle %></h5>
                </div>
                <div class="panel-body">
                    <p>
                       
                    </p>
                    <p>
                       
                    </p>
                    <div class="text-center">
              
                    </div>

                    <div class="m-t-md">
                   
                    </div>
                </div>
            </div>
        </div> -->
        </div>
            </asp:PlaceHolder>

        <asp:PlaceHolder ID="phTrainee" runat="server">
            <br />
             <div class="col-md-12 alert alert-warning" style="padding:8px !important;">
                       <p class="filters ">
  <label>
    <input type="radio" name="filter" class="alert alert-danger" value="*" checked="checked" /> show all </label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".AbatementWorkertrainedonlyW2" /> Abatement Worker</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".InspectorTechnicianIT" /> Inspector Technician</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".MaintenanceandRepaintingSupervisorS4" /> Maintenance and Repainting Supervisor</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".ProjectDesignertrainedonlyPD" /> Project Designer</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".RemovalandDemolitionSupervisorS2" /> Removal and Demolition Supervisor</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".RiskAssessorRA" /> Risk Assessor</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".StructuralSteelSupervisorS1" /> Structural Steel Supervisor</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".StructuralSteelWorkertrainedonlyW1" /> Structural Steel Worker</label><label>&nbsp;&nbsp;
    <input type="radio" name="filter" value=".VisualInspectorVI" /> Visual Inspector</label>&nbsp;&nbsp;
    </p>
                    </div>
                    <!-- //.col-md-12 -->
           
                         <div class="col-md-12">
                         <div class="grid">
                            <asp:Panel ID="pnlListofCourses" runat="server"></asp:Panel>
                        </div>
             </div>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </asp:PlaceHolder>

         <asp:PlaceHolder ID="phCertAccedit" runat="server">
             <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                           My Applications
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example3" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Title </th>
                                                    <th>Application for</th>
                                                    <th>Submitted on </th>
                                                    <th>Status</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlMyCourses" runat="server"></asp:Panel>
											</tbody>
                                     </table>
                </div>
        </div>
    </div>     
        </div>
        </asp:PlaceHolder>

    </div>

    <asp:Label ID="lblerror" runat="server" ></asp:Label>
    <br /><br />
      

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



                // quick search regex
var qsRegex;

// init Isotope
var $grid = $('.grid').isotope({
  itemSelector: '.element-item',
  layoutMode: 'fitRows',
  filter: function() {
    return qsRegex ? $(this).text().match( qsRegex ) : true;
  }
});

// use value of search field to filter
var $quicksearch = $('.quicksearch').keyup( debounce( function() {
  qsRegex = new RegExp( $quicksearch.val(), 'gi' );
  $grid.isotope();
}, 200 ) );
// filter functions
var filterFns = {
  // show if number is greater than 50
  numberGreaterThan50: function() {
    var number = $(this).find('.number').text();
    return parseInt( number, 10 ) > 50;
  },
  // show if name ends with -ium
  ium: function() {
    var name = $(this).find('.name').text();
    return name.match( /ium$/ );
  }
};

// bind filter on radio button click
$('.filters').on( 'click', 'input', function() {
  // get filter value from input value
  var filterValue = this.value;
  // use filterFn if matches value
  filterValue = filterFns[ filterValue ] || filterValue;
  $grid.isotope({ filter: filterValue });
});




                   
		    })
            
         
		</script>
    
</asp:Content>

