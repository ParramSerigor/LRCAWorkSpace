<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TP_AddLocations.aspx.cs" Inherits="LRCA.TP_AddLocations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPMain" runat="server">
<div class="transition animated fadeIn">
      <div class="hpanel">
        <div class="panel-body">
            <h2 class="font-light m-b-xs" style="color:#AB1027"><span class="font-uppercase">
          Add Locations</span>         
            </h2>
            <small>Add locations to the Training Provider </small>
        </div>
          <div class="input-group"><div class="input-group-btn"><a href="#" onclick="return history.back();" class="btn btn-primary">Back</a></div><div class="alert alert-success" style="padding:8px !important;">&nbsp;</div></div>
    </div>
    <asp:Label ID="lblerror" runat="server" ></asp:Label>
    <div class="row">
        <div class="col-lg-12">
                <div class="hpanel collapsed">         
                    <div class="panel-heading">
                        <a class="showhide">
                            <div class="panel-tools">
                                <i class="fa fa-chevron-up"></i>
                            </div>
                       Click Here to Add Locations
                        </a>
                    </div>
                              <div class="panel-body">
                          <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group"><label class="col-sm-10 control-label">Training Provider</label>
                        <asp:DropDownList ID="dropTPs" CssClass="form-control m-b" ToolTip="Accreditated Training Providers"  runat="server"></asp:DropDownList><span class="help-block m-b-none">Select Accreditated Training Provider from the dropdown list.</span>
                    </div></div>
                </div>
                         <br />
                <div class="row">
                      <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Address</label>

                     <div >
                        <asp:TextBox ID="txtAddress_1" class="form-control" placeholder="Address line 1" title="Address line 1" runat="server" required></asp:TextBox>
                    </div></div></div>
                 
                          
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">City</label>

                     <div >
                        <asp:TextBox ID="txtCity" class="form-control" placeholder="City" title="City" runat="server" required></asp:TextBox>
                    </div></div></div>

                          
                </div>
                <br />
                 <div class="row">
                  
                   <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">State</label>

                     <div >
                        <asp:TextBox ID="txtState" class="form-control" placeholder="State" title="State" runat="server" required></asp:TextBox> 
                    </div></div></div>
                          
                    <div class="col-lg-6">
                        <div class="form-group"><label class="col-sm-10 control-label">Zip Code</label>

                     <div >
                        <asp:TextBox ID="txtZipCode" class="form-control" placeholder="Zip Code" title="Zip Code" runat="server" required></asp:TextBox>
                    </div></div></div>
                          
                </div>
            
                </div>

                    <div class="panel-footer">
                        <asp:Button ID="btnAddCourse" runat="server" CssClass="btn btn-success" OnClick="AddTManual_Click" Text="Add Location" />
                    </div>
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
                           Locations
                        </a>
                    </div>
                              <div class="panel-body">
                                 <table id="example1" class="table table-striped table-bordered table-hover" >
                    <thead>
												<tr>
                                                    <th>Address</th>
                                                    <th>City</th>
                                                    <th>State</th>
                                                    <th>Zip Code</th>
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
            $("#CPMain_txtZipCode").inputmask({
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
