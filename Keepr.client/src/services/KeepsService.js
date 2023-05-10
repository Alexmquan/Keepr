import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepsService {
  async createKeep(keepData) {
    const res = await api.post("api/keeps", keepData)
    // logger.log('[New Keep]', res.data)
    AppState.keeps.push(new Keep(res.data))
  }

  async getKeeps() {
    AppState.profile = {}
    const res = await api.get("api/keeps")
    // logger.log("[Get Keeps Data]", res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async setActiveKeep(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.activeKeep = new Keep(res.data)
    // const activeKeep = AppState.keeps.find(k => k.id == keepId)
    // AppState.activeKeep = activeKeep
    // if (activeKeep.creatorId != AppState.account.id) {
    //   AppState.activeKeep.views++
    // }
  }

  async editKeep(keepData) {
    // logger.log('[Kept Test keepData - prerequest]', keepData)
    const res = await api.put(`api/keeps/${keepData.id}`, keepData)
    // logger.log('[Kept Test keepData - postrequest]', res.data)
    AppState.activeKeep = new Keep(res.data)
  }

  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    const index = AppState.keeps.findIndex(k => k.id == keepId)
    AppState.keeps.splice(index, 1)
  }

}

export const keepsService = new KeepsService();