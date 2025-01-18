var get_id;

function showmessage(id) {
    get_id = id;
    $('#del').modal('show');
}

function confirmdelete() {

    window.location.href="DeleteCategories?id=" + get_id //Pom  لتوجيه المستند توجيه النافذة

}


function confirmdelete1() {
    $.ajax({
        url: 'DeleteCategories',
        type: 'get',
        data: {id : get_id},
        
        success : function(result){
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "  تم الحذف بنجاح "
            });
            $('#del').modal('hide');
            $('#categoriescontainer').html(result)
        }

    });
}