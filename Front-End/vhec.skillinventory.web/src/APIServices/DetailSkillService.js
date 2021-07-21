import http from '../BaseConnect/Http-comman'
class DetailSkillSevice {
    postSkill(x) {
        return http.post("api/DetailSkill/", x)
    }
}
export default new DetailSkillSevice()