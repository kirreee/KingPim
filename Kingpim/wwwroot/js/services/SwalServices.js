app.service('SwalService', function () {

    //Success Swal
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