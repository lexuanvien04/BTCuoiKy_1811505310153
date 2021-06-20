var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click',
            function (e) {
                e.preventDefault(); 
                 var btn = $(this);
                var id = parseInt(btn.data('id'));
                $.ajax(
                    {
                        url: "~/Admin/UserAccount/ChangeStatus",
                        data: { id: id },
                        dataType: "json", 
                        type: "POST",
                        success: function (response) {
                            console.log(response);
                            if (response.status == true) {
                                btn.text('Actived');
                                btn.removeClass('btn-danger')
                                btn.addClass('btn-instagram')
                            }
                            else {
                                btn.text('Blocked');
                                btn.removeClass('btn-instagram')
                                btn.addClass('btn-danger')
                            }
                        }
                    })
            });
    } 
}
user.init();