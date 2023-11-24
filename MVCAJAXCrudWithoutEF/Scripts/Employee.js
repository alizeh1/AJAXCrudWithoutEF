
//Load data in a table when document is ready


$(document).ready(function () {
    loadData();
});

//load data function
function loadData() {
    $.ajax({
        url: "/Employee/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",    //This line specifies the content type of the request payload
        dataType: "json",                                 //This line specifies the expected data type of the response. 
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.EmployeeID + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.State + '</td>';
                html += '<td>' + item.Country + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delete(' + item.EmployeeID + ')">Delete</a></td>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responsetext);
        }
    });
}

function resetModal() {
    $('#EmployeeID').val('');
    $('#Name').val('');
    $('#Age').val('');
    $('#State').val('');
    $('#Country').val('');
}

//Add data Function
function Add() {
    
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),                 //Always remember when u declare parameter its name same as ur property class name
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        State: $('#State').val(),
        Country:$('#Country').val()
    };
    $.ajax({
        url: "/Employee/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;chartset=utf-8",
        dataType: "json",
        success: function () {                                       //defind or not result in funtion in your choice code work properly
            loadData();
            resetModal(); // Call the function to reset the modal
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responsetext);
        }
    });
}

// Function for getting the Data Based upon Employee ID
function getbyID(EmpID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Employee/GetbyID/" + EmpID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#EmployeeID').val(result.EmployeeID);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);
            $('#State').val(result.State);
            $('#Country').val(result.Country);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responsetext);
        }
    });
    return flase;
}

// Function for updating employee's record
function Update() {
    var empObj = {
        EmployeeID:$('#EmployeeID').val(),
        Name:$('#Name').val(),
        Age:$('#Age').val(),
        State:$('#State').val(),
        Country:$('#Country').val(),
    };
    $.ajax({
        url: "/Employee/UpdateEmp",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#State').val("");
            $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responsetext);
        }
    });
}

// Function for deleting employee's record
function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Employee/DeleteEmp/" + ID,
            type: "POST",
            contentType:"application/json;charset=UTF-8",
            dataType: "json",
            success: function () {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responsetext);
            }
        });
    }
}

