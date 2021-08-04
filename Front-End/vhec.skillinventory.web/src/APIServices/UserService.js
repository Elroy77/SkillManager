import http from '../BaseConnect/Http-comman'
class UserService {
    Login() {
        return http.post("api/Login/")
    }
}
export default new UserService()