<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="LRCA.CourseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          <%=CourseTitle %></span>         
            </h2>
            <p class="lead" style="font-size:15px"><%=CourseDesc %></p>
            <h5 style="font-weight:normal;">Language: <%=AttendenceReq %></h5><br />
        </div>
          <div class="input-group"><div class="input-group-btn"><a href="#" onclick="return history.back();" class="btn btn-primary">Back</a></div><div class="alert alert-success" style="padding:8px !important;">&nbsp;</div></div>
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
                           Scheduled Classes
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
													<th>Title </th>
                                                    <th>Start - End Dates</th>
                                                    <th>Language</th>
                                                    <th>Location</th>
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
       
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
     <script type="text/javascript">
     $(document).ready(function () {
     $(document).on("click", ".open-Enroll", function () {
		            var DeleteId = $(this).data('id');
		            if (confirm('Are you sure you want to Enroll for this Course?')) {
		                CallAjaxEnroll(DeleteId);
		            }
         });
        });

        function CallAjaxEnroll(cgi) {
		        $.ajax({
		            type: "POST",
		            url: "CourseDetails.aspx/Enroll",
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
