$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quatity = 1;
        var tQuantity = $('#qty').val() || 1;
        if (isNaN(tQuantity) || tQuantity == '') {
            tQuantity = $('#qty').text(); // Nếu input bị lỗi hoặc rỗng, lấy giá trị text
        }

        if (tQuantity != '') {
            quatity = parseInt(tQuantity);
        }
        $.ajax({
            url: '/Cart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success) {
                    $("#numBooksInCart").html(rs.count);                   
                }else {
                    alert(rs.msg); // Hiển thị thông báo khi thêm sản phẩm thất bại
                }
            }
        });
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?')
        if (conf) {
            $.ajax({
                url: '/Cart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $("#numBooksInCart").html(rs.count);
                        $('#trow_' + id).remove();

                        // Tính lại tổng tiền
                        var totalPay = 0;
                        $("tr[id^='trow_']").each(function () {
                            var totalPrice = $(this).find('td:nth-child(3)').text().replace('₫', '').replace(/,/g, ''); // Lấy giá và loại bỏ ký tự ₫
                            totalPay += parseFloat(totalPrice);
                        });

                        // Cập nhật tổng tiền
                        $("#totalPay").html(totalPay.toLocaleString() + '₫');

                        // Nếu giỏ hàng trống, ẩn dòng tổng thanh toán
                        if (rs.isEmpty) {
                            $("#ThanhToanCD").remove();
                           
                        }
                    } else {
                        alert(rs.msg); // Hiển thị thông báo khi thêm sản phẩm thất bại
                    }
                }
            });
        }
    });
})

function ShowCount() {
    $.ajax({
        url: '/Cart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $("#numBooksInCart").html(rs.count);
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/Cart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $("#load_data").html(rs);
        }
    });
}



