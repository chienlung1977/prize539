
//中文字
function isChina(s) {
    var patrn = /[\u4E00-\u9FA5]|[\uFE30-\uFFA0]/gi;
    if (!patrn.exec(s)) {
        return false;
    }
    else {
        return true;
    }
}



//行動電話
function isMobile(s) {
    var patrn = /^[09]{2}[0-9]{8}$/;
    if (!patrn.exec(s)) {
        return false;
    }
    else {
        return true;
    }
}


//一般電話
function isphone(s) {
    var patrn = /^[0]{1}[2-8]{1}[0-9]{7,8}$/;
    if (!patrn.exec(s)) {
        return false;
    }
    else {
        return true;
    }
}

//email
function isMail(s) {
    var patrn = /^\S+@\S+\.\S+$/;
    if (!patrn.exec(s)) {
        return false;
    }
    else {
        return true;
    }
}

//身份證字號
function isIdno(s) {
    var patrn = /[A-Za-z]{1}[1-2]{1}[0-9]{8}/ig;
    if (!patrn.exec(s)) {
        return false;
    }
    else {
        return true;
    }
}







//===========================================

/*
只能輸入正整數
onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}"

//自動跳下一欄位
$(function(){	
		
		$('input').keyup(function(e){   
			if($(this).val().length==$(this).attr('maxlength'))   
			$(this).next(':input').focus();   
		});  
		
	});


// 信用卡卡號自動跳下欄位
$('body').find('#coupon-focus').children('input').focus().select();
$('body').find('#coupon-focus').children('input').keyup( function(e){
// 限制只能輸入數字
  if(!/^\d+$/.test(this.value)){
    var newValue = /^\d+/.exec(this.value);
    newValue != null ? $(this).val(newValue) : $(this).val('');
    }
  this.value.length == this.getAttribute('maxlength') && $(this).next().focus();
});

*/


