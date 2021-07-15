import http from '../BaseConnect/Http-comman'
class SkillSevice {
    getAllSk() {
        return http.get("api/Skill/")
    }
}
export default new SkillSevice()