import http from '../BaseConnect/Http-comman'
class EmployeeSevice {
    getAll() {
        return http.get("api/employee/")
    }
}
export default new EmployeeSevice()