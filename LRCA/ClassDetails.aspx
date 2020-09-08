<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ClassDetails.aspx.cs" Inherits="LRCA.ClassDetails" %>
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
            <div class="row" >
                 <div class="col-lg-6">
                      <div class="row">
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold" >Language</div>
                                        <small style="font-size:12px"><%=language %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold">Start Date</div>
                                        <small style="font-size:12px"><%=strStartDate %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold">End Date</div>
                                        <small style="font-size:12px"><%=strEndDate %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold">Duration</div>
                                        <small style="font-size:12px"><%=strDuration %></small>
                                    </div>
                                </div>
                    </div>
                <div class="col-lg-6">
                     <div class="row">
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold" >Instructor</div>
                                        <small style="font-size:12px"><%=strInstructor %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold" >Location</div>
                                        <small style="font-size:12px"><%=strLocation %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold" >Cost</div>
                                        <small style="font-size:12px"><%=strCost %></small>
                                    </div>
                                    <div class="col-sm-3" style="">
                                        <div class="project-label font-uppercase" style="font-weight:bold" >Phone/s</div>
                                        <small style="font-size:12px"><%=strPhone %></small>
                                    </div>
                                </div>
                </div>
            </div>
           
        </div>


          <asp:Panel ID="pnlAddButton" runat="server"></asp:Panel>
    </div>
   
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
   
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
		            url: "ClassDetails.aspx/Enroll",
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
