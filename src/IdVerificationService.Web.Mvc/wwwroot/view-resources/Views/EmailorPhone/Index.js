(function ($) {
    var _nviService = abp.services.app.nvi,
        l = abp.localization.getSource('IdVerificationService'),
        _$modal = $('#UserCreateModal'),
        _$form = _$modal.find('form');


    $(document).on('click', '#btn1', function (e) {
       
        _nviService.sendEmail("gzm@gmail.com").done(result => {
            if (result == true) {
                swal("Başarılı!", "Mail gönderildi!", "success");
            } else {
                swal("Başarısız!", "Mail gönderilemedi!", "error");
            }
        });


    });
    $(document).on('click', '#btn2', function (e) {
        var phoneNumber = $("#PhoneNumber").val();
        _nviService.sendEmail('05313057994').done(result => {
            if (result = true) {
                swal("Başarılı!", "SMS gönderildi!", "success");
            } else {
                swal("Başarısız!", "SMS gönderilemedi!", "error");
            }
        });


    });

})(jQuery);
