import http from '../BaseConnect/Http-comman'
class EmployeeSevice {
    getAllEmpl() {
        return http.get("api/employee/")
    }

    getlistEmpl(name) {
        return http.get("api/employee/?FullName=" + name)
    }

    getlistEmplNS(fullname, skillname) {
        return http.get("api/employee/search/?fullname=" + fullname + "&skillname=" + skillname)
    }

    getByIdEmpl(id) {
        return http.get("api/employee/" + id)
    }

    postEmpl(x) {
        return http.post("api/employee/", x)
    }

    putEmpl(id, x) {
        return http.put("api/employee/" + id, x)
    }

    deleteEmpl(id) {
        return http.delete("api/employee/" + id)
    }
    getValuePosition() {
        return http.get("api/employee/PositionInventory")
    }
}
export default new EmployeeSevice()