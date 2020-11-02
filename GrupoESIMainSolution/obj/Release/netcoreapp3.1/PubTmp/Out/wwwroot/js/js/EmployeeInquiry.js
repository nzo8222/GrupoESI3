var dataTable;

$(document).ready(function (employerId) {
    loadDataTable(employerId)
});

function loadDataTable(employerId) {
    dataTable = $("#tblData").dataTable({
        "ajax": {
            "url": "/Controllers/EmployeeController/GetInquiryList" + employerId
        },
        "columns": [

            { "data": "Name", "width": "10%" },
            { "data": "Email", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Employees/EmployeeDetails/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                            </div>
                           `;
                }
            },
            { "width": "5%" }
            ]

    })
}
