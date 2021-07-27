import http from '../BaseConnect/Http-comman'
class SkillSevice {
    getAllSk() {
        return http.get("api/Skill/")
    }
    getSkillName() {
        return http.get("api/skill/name")
    }
    getSkillInventory() {
        return http.get("api/skill/Inventory")
    }
}
export default new SkillSevice()