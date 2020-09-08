<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inst_ScheduleClass.aspx.cs" Inherits="LRCA.Inst_ScheduleClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
    <script type="text/javascript" src="CSSBackEnd/js/jquery.inputmask.bundle.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Schedule a Class</span>         
            </h2>
            <small>Please, fill out the form below and click on submit button to schedule a Class.</small>
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
                       Click here to Add a schedule for a Class
                        </a>
                    </div>
                   
            <div class="panel-body">
                 <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Training Provider</label>
                        <asp:DropDownList ID="dropTPs" CssClass="form-control m-b" ToolTip="Accreditated Training Providers" OnSelectedIndexChanged="Populate_Instructors" AutoPostBack="true" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select Accreditated Training Provider from the dropdown list.</span>
                    </div></div>
                </div>
                     <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Instructors</label>
                        <asp:DropDownList ID="dropInst" CssClass="form-control m-b" ToolTip="Instructors" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select Instructors from the dropdown list.</span>
                    </div></div>
                </div>
                 <div class="row">
                     <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Courses</label>
                    <div >
                        <asp:DropDownList ID="dropCourses" CssClass="form-control m-b" ToolTip="Courses" runat="server"></asp:DropDownList><span class="help-block m-b-none">Select a Course from the dropdown list.</span>
                    </div></div></div>
                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Title</label>

                    <div >
                        <asp:TextBox ID="txtCTitle" class="form-control" placeholder="Class Title" title="Class Title" runat="server" required></asp:TextBox>
                    </div></div></div>
                 </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Class Description</label>
                            
                    <div >
                        <asp:TextBox ID="txtCDesc" class="form-control" placeholder="Class Description" TextMode="MultiLine" Rows="6"    title="Class Description" runat="server" ></asp:TextBox>
                    </div></div></div>
                    </div>
                <br />
                 <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Start Date/Time</label>                            
                    <div >
                        <asp:TextBox ID="txtStartDate" class="form-control" placeholder="Start Date" title="Start Date" runat="server" required></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">End Date/Time</label>                            
                    <div>
                        <asp:TextBox ID="txtEndDate" class="form-control" placeholder="End Date" title="End Date" runat="server" required></asp:TextBox>
                    </div></div></div>
                      <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Location</label>                            
                    <div>
                    <asp:DropDownList ID="dropLocation" CssClass="form-control m-b" ToolTip="Location" runat="server"></asp:DropDownList>    
                    </div></div></div>

                    </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Language</label>
                            
                    <div >
                       <asp:DropDownList ID="dropLanguage" CssClass="form-control m-b" ToolTip="Class Language" runat="server">
                          <asp:ListItem Selected="True" Value="English"> English </asp:ListItem>
                           <asp:ListItem Value="Spanish"> Spanish </asp:ListItem>
                       </asp:DropDownList>
                    </div></div></div>
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Registration Limit</label>
                          
                    <div >
                        <asp:TextBox ID="txtRegisterLimit" class="form-control" placeholder="Registeration Limit" title="Registration Limit" runat="server" required></asp:TextBox>
                    </div></div></div>
                    <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Minimum Enrollment</label>
                            
                    <div >
                         <asp:TextBox ID="txtMinEnroll" class="form-control" placeholder="Minimum Enrollment" title="Minimum Enrollment" runat="server" required></asp:TextBox>
                    </div></div></div>
                     <div class="col-lg-4">
                        <div class="form-group"><label class="col-sm-10 control-label">Course Price</label>
                            
                    <div >
                         <asp:TextBox ID="txtCost" class="form-control" data-inputmask="'alias': 'decimal', 'groupSeparator': ',', 'autoGroup': true, 'digits': 2, 'digitsOptional': false, 'prefix': '$ ', 'placeholder': '0'"  placeholder="Course Price" title="Course Price" runat="server" required></asp:TextBox>
                    </div></div></div>
                </div>
                 </div>
                     <div class="panel-footer">
                        <asp:Button ID="btnAddClass" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Submit" />
                    </div>
          </div></div></div>
    <br />
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
                                                    <th>Registration Limit</th>
                                                    <th>Course Fee</th>
                                                    <th>Location</th>
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
   </div>    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPPageRelatedJavascript" runat="server">
   <script type="text/javascript">
        $(document).ready(function () {
            $(":input").inputmask();

            $("#CPMain_txtPhone").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtSSNO").inputmask({
                mask: '999-99-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: true
            });
            $("#CPMain_txtZipCode_1").inputmask({
                mask: '99999',
                placeholder: ' ',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
           
            $("#CPMain_txtTrainingCardNum").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtACCID").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtContractorAccdNum").inputmask({
                mask: '99999',
                placeholder: '99999',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });
            $("#CPMain_txtICContactPhone").inputmask({
                mask: '999-999-9999',
                placeholder: '*',
                showMaskOnHover: true,
                showMaskOnFocus: false
            });

            $('#CPMain_txtStartDate').datepicker({});
            $('#CPMain_txtEndDate').datepicker({});
            
         $("#form1").validate({
             rules: {
                ctl00$CPMain$txtCost: {
					required: true,
                    minlength: 0,
                    maxlength: 10
                 },
                 ctl00$CPMain$txtMinEnroll: {
					required: true,
                    minlength: 0,
                    maxlength: 3
                 },
                 ctl00$CPMain$txtRegisterLimit: {
					required: true,
                    minlength: 0,
                    maxlength: 3
                 }

			},
             messages: {
                ctl00$CPMain$txtCost: {
                    minlength: "Dollar value should not exceeds over TEN thousand!",
                    maxlength: "Dollar value should not exceeds over TEN thousand!"
                 },
                 ctl00$CPMain$txtMinEnroll: {
                    minlength: "Minimum Enrollment should not exceeds 100!",
                    maxlength: "Minimum Enrollment should not exceeds 100!"
                 },
                 ctl00$CPMain$txtRegisterLimit: {
                    minlength: "Registration Limit should not exceeds 100!",
                    maxlength: "Registration Limit should not exceeds 100!"
				}

			}
		});
        });
       
        </script>
</asp:Content>
