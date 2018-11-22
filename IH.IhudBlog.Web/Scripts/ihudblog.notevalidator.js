$(document).ready(function ()   
{  
    $('#noteFormId').validate({  
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',  
        errorPlacement: function (error, e) {  
            e.parents('.form-group > div').append(error);  
        },  
        highlight: function (e) {  
    
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');  
            $(e).closest('.help-block').remove();  
        },  
        success: function (e) {  
            e.closest('.form-group').removeClass('has-success has-error');  
            e.closest('.help-block').remove();  
        },  
        rules: {  
            'Title': {  
                required: true,  
                minlength: 5,
				
            },
  
            'Text': {  
                required: true,  
                minlength: 1  
            }  
        },  
        messages: {  
            'Title': 'Пожалуйста введите заголовок не менее пяти символов',  
  
            'Text': {  
                required: 'Пожалуйста введите текст',  
                minlength: 'Введите хотя бы один символ'  
            }
        }  
    });  
});   