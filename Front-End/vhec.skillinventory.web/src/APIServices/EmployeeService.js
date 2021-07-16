import http from '../BaseConnect/Http-comman'
class EmployeeSevice {
    getAllEmpl() {
        return http.get("api/employee/")
    }

    getlistEmpl(name) {
        return http.get("api/employee/?FullName="+name)
    }

    getByIdEmpl(id) {
        return http.get("api/employee/"+id)
    }

    postEmpl(x) {
        return http.post("api/employee/", x)
    }

    putEmpl(id, x) {
        return http.put("api/employee/"+id, x)
    }

    deleteEmpl(id) {
        return http.delete("api/employee/"+id)
    }
}
export default new EmployeeSevice()