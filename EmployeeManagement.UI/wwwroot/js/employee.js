

$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});

function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:6001/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h4>${result.name}</h4>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard).toggle();
                //showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $(".employeeDelete").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");
        var deleteEmployee = confirm("ARE YOU SURE YOU WANT TO DELETE");
        if (deleteEmployee) {
            $.ajax({
                url: 'https://localhost:6001/api/internal/employee/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {

                    location.reload();

                    alert("SUCCESSFULLY DELETED")

                    //$("#EmployeeCard").html(newEmployeeCard);
                    showEmployeeDetailCard();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
        else {
            alert("DELETION CANCELLED")
        }
    });

    $("#createform").submit(function (event) {
        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Name = $("#name").val();
        employeeDetailedViewModel.Department = $("#dept").val();
        employeeDetailedViewModel.Age = Number($("#age").val());
        employeeDetailedViewModel.Address = $("#address").val();

        var data = JSON.stringify(employeeDetailedViewModel);//convertion

        $.ajax({
            url: 'https://localhost:6001/api/internal/employee/employeeinsert',
            type: 'POST',
            dataType:"application/json; charset=utf-8",
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
        alert("INSERTED SUCCESSFULLY");
    });

    $(".employeeEdit").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:6001/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#editid").val(result.id)
                $("#editname").val(result.name)
                $("#editdept").val(result.department)
                $("#editage").val(result.age)
                $("#editaddress").val(result.address)
            },
            error: function (error) {
                console.log(error);
            }
        });

        $("#update").submit(function (event) {

            var Employee = {};
            Employee.Id = Number($("#editid").val());
            Employee.Name = $("#editname").val();
            Employee.Department = $("#editdept").val();
            Employee.Age = Number($("#editage").val());
            Employee.Address = $("#editaddress").val();

            var data = JSON.stringify(Employee);

            $.ajax({
                url: 'https://localhost:6001/api/internal/employee/employeeedit',
                type: 'PUT',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: data,
                success: function (result) {
                    location.reload();
                },

                error: function (error) {
                    console.log(error);
                }
            });
            alert("EDITED SUCCESSFULLY");
        });
    });
}

    /*function hideEmployeeDetailCard() {
        $("#EmployeeCard").hide();
    }*/

    function showEmployeeDetailCard() {
        $("#EmployeeCard").show();
    }
