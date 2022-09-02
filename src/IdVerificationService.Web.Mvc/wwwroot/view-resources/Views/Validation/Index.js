(function ($) {
    var _nviService = abp.services.app.nvi,
        l = abp.localization.getSource('IdVerificationService')
    _$modal = $('.container'),
        _$form = _$modal.find('form');



    $(document).on('click', '.btn-valid', function (e) {
        var citizenId = $("#CitizenId").val();
        var name = $("#Name").val();
        var surname = $("#Surname").val();
        var birthYear = $("#BirthYear").val();

        _nviService.kimlikBilgileriniDogrula(
            {
                CitizenId: citizenId,
                Name: name,
                Surname: surname,
                BirthYear: birthYear
            }
        ).done(function (result) {
            //alert(result);
            if (result == 'false') {
                swal({
                    title: "Hatalı giriş",
                    text: "Bilgilerinizi gözden geçiriniz!",
                    icon: "error",
                    button: "Tekrar Deneyin!",
                });
            }
            else {
                window.location.href = "/EmailorPhone/Index?auth=" + result;

            }
        }).always(function () {

        });

    });

    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //Response.AppendHeader("Pragma", "no-cache")
    //Response.Expires = -1;


})(jQuery);
