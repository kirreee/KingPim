app.service('SwalService', function () {

    //Show swal with message.
    this.swalShow = function (swalObj) {

        Swal.fire({
            title: swalObj.title,
            type: swalObj.type
        }).then(function () {
            location.reload();
        });

        return;
    };
});