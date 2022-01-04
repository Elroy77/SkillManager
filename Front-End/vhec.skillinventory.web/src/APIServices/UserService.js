import http from '../BaseConnect/Http-comman'
class UserService {
    Login(info) {
        return http.post("api/Login/", info)
    }
}
export default new UserService()