﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcNoticeCompose.ascx.cs" Inherits="LRCA.CSSBackEnd.ajax.wcNoticeCompose" %>

<h2 class="email-open-header">
	Compose New Email <span class="label txt-color-white">DRAFT</span>
	<a href="javascript:void(0);" rel="tooltip" data-placement="left" data-original-title="Print" class="txt-color-darken pull-right"><i class="fa fa-print"></i></a>	
</h2>

    <div class="form-horizontal">
	<div class="inbox-info-bar no-padding">
		<div class="row">
			<div class="form-group">
				<label class="control-label col-md-1"><strong>To</strong></label>
				<div class="col-md-11">
					<select multiple style="width:100%" class="select2" data-select-search="true">
						<option value="sunny.orlaf@smartadmin.com">sadi.orlaf@smartadmin.com</option>
						<option value="rachael.hawi@smartadmin.com">rachael.hawi@smartadmin.com</option>
						<option value="michael.safiel@smartadmin.com">michael.safiel@smartadmin.com</option>
						<option value="alex.jones@infowars.com">alex.jones@infowars.com</option>
						<option value="oruf.matalla@gmail.com">oruf.matalla@gmail.com</option>
						<option value="hr@smartadmin.com">hr@smartadmin.com</option>
						<option value="IT@smartadmin.com" selected="selected">IT@smartadmin.com</option>
					</select>
					<em><a href="javascript:void(0);" class="show-next" rel="tooltip" data-placement="bottom" data-original-title="Carbon Copy">CC</a></em>
				</div>
			</div>
		</div>	
	</div>
	
	<div class="inbox-info-bar no-padding hidden">
		<div class="row">
			<div class="form-group">
				<label class="control-label col-md-1"><strong>CC</strong></label>
				<div class="col-md-11">
					<select multiple style="width:100%" class="select2" data-select-search="true">
						<option value="sunny.orlaf@smartadmin.com" selected="selected">sunny.orlaf@smartadmin.com</option>
						<option value="rachael.hawi@smartadmin.com" selected="selected">rachael.hawi@smartadmin.com</option>
						<option value="michael.safiel@smartadmin.com">michael.safiel@smartadmin.com</option>
						<option value="alex.jones@infowars.com">alex.jones@infowars.com</option>
						<option value="oruf.matalla@gmail.com">oruf.matalla@gmail.com</option>
						<option value="hr@smartadmin.com">hr@smartadmin.com</option>
						<option value="IT@smartadmin.com">IT@smartadmin.com</option>
					</select>
					<em><a href="javascript:void(0);" class="show-next" rel="tooltip" data-placement="bottom" data-original-title="Blind Carbon Copy">BCC</a></em>
				</div>
			</div>
		</div>	
	</div>

	<div class="inbox-info-bar no-padding hidden">
		<div class="row">
			<div class="form-group">
				<label class="control-label col-md-1"><strong>BCC</strong></label>
				<div class="col-md-11">
					<select multiple style="width:100%" class="select2" data-select-search="true">
						<option value="sunny.orlaf@smartadmin.com">sunny.orlaf@smartadmin.com</option>
						<option value="rachael.hawi@smartadmin.com">rachael.hawi@smartadmin.com</option>
						<option value="michael.safiel@smartadmin.com">michael.safiel@smartadmin.com</option>
						<option value="alex.jones@infowars.com">alex.jones@infowars.com</option>
						<option value="oruf.matalla@gmail.com">oruf.matalla@gmail.com</option>
						<option value="hr@smartadmin.com">hr@smartadmin.com</option>
						<option value="IT@smartadmin.com">IT@smartadmin.com</option>
					</select>
				</div>
			</div>
		</div>	
	</div>
	
	<div class="inbox-info-bar no-padding">
		<div class="row">
			<div class="form-group">
				<label class="control-label col-md-1"><strong>Subject</strong></label>
				<div class="col-md-11">
					<input class="form-control" placeholder="Email Subject" type="text">
					<em><a href="javascript:void(0);" class="show-next" rel="tooltip" data-placement="bottom" data-original-title="Attachments"><i class="fa fa-paperclip fa-lg"></i></a></em>
				</div>
			</div>
		</div>	
	</div>

	<div class="inbox-info-bar no-padding hidden">
		<div class="row">
			<div class="form-group">
				<label class="control-label col-md-1"><strong>Attachments</strong></label>
				<div class="col-md-11">
					<input class="form-control fileinput" type="file" multiple="multiple">
				</div>
			</div>
		</div>	
	</div>
	
	<div class="inbox-message no-padding">
	
		<div id="emailbody">
			
				<br><br><br><br><br>Thanks,<br><strong>John Doe</strong><br><br><small>CEO - SmartAdmin <br> 231 Ajax Rd, Detroit MI - 48212, USA<br><i class="fa fa-phone"> (313) 647 4761</i></small><br><img src="img/logo-blacknwhite.png" height="20" width="auto" style="margin-top:7px; padding-right:9px; border-right:1px dotted #9B9B9B;" />		
		</div>	
	</div>
	
	<div class="inbox-compose-footer">

	<button class="btn btn-danger" type="button">
		Disregard
	</button>
		
	<button class="btn btn-info" type="button">
		Draft
	</button>

	<button data-loading-text="&lt;i class='fa fa-refresh fa-spin'&gt;&lt;/i&gt; &nbsp; Sending..." class="btn btn-primary pull-right" type="button" id="send">
		Send <i class="fa fa-arrow-circle-right fa-lg"></i>
	</button>


	</div>
</div>

<script type="text/javascript">

    // DO NOT REMOVE : GLOBAL FUNCTIONS!

    runAllForms();

    // PAGE RELATED SCRIPTS

    $(".table-wrap [rel=tooltip]").tooltip();



    $('#emailbody').summernote({
        height: 250,
        focus: false,
        tabsize: 2
    });


    $(".show-next").click(function () {
        $this = $(this);
        $this.hide();
        $this.parent().parent().parent().parent().parent().next().removeClass("hidden");
    })

    $("#send").click(function () {

        var $btn = $(this);
        $btn.button('loading');

        // wait for animation to finish and execute send script
        setTimeout(function () {
            //Insert send script here


            // Load inbox once send is complete

            loadURL("ajax/email/email-list.html", $('#inbox-content > .table-wrap'))


        }, 1000); // how long do you want the delay to be? 
    });


</script>
