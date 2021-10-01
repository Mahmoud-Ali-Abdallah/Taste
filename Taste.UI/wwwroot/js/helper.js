function CustomConfirm(title, message, type) {
    return new Promise((resolve) => {
        return Swal.fire({
            title: title,
            text: message,
            type: type,
            icon: type,
            showCancelButton: true,
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirm Operation',
            confirmButtonText: 'Confirm',
            showLoaderOnConfirm: true,
        }).then((result) => {
            if (result.value) {
                resolve(true);
            }
            else {
                resolve(false);
            }
        });
    });
}