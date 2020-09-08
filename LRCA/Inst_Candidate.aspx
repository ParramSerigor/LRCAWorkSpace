<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inst_Candidate.aspx.cs" Inherits="LRCA.Inst_Candidate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          List of Trainees </span>         
            </h2>
            <h4><asp:Label ID="lblCrouseName" runat="server" ></asp:Label></h4>
            <small>Please, click on the check box to approve.</small>
        </div>
          <asp:Panel ID="pnlAppStatus" runat="server"></asp:Panel>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   
 <div class="row">
        <div class="col-lg-12">
                <div class="hpanel">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                       List of trainees
                        </a>
                    </div>
                   
            <div class="panel-body">
    
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>First Name </th>
                                                    <th>Last Name </th>
                                                    <th>Email</th>
                                                    <th>Location</th>
                                                    <th>Instructor</th>
                                                    <th>Starts / Ends</th>
                                                    <th></th>
												</tr>
											</thead>
											<tbody>
                                                <asp:Panel ID="pnlVideos" runat="server"></asp:Panel>
											</tbody>
                                     </table>
                
                 </div>
                    </div>
          </div></div></div>
    <br />
   
       
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
     <script type="text/javascript">
     $(document).ready(function () {
     $(document).on("click", ".open-Enroll", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Approved this User?')) {
		                CallAjaxEnroll(DeleteId);
		            }
         });
        });

        function CallAjaxEnroll(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "Inst_Candidate.aspx/Enroll",
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
