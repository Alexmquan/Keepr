import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepsService {
  async createKeep(keepData) {
    const res = await api.post("api/keeps", keepData)
    logger.log('[New Keep]', res.data)
    AppState.keeps.push(new Keep(res.data))
  }

  async getKeeps() {
    const res = await api.get("api/keeps")
    logger.log("[Get Keeps Data]", res.data)
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async setActiveKeep(keepId) {
    const activeKeep = AppState.keeps.find(k => k.id == keepId)
    AppState.activeKeep = activeKeep
  }

  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    const index = AppState.keeps.findIndex(k => k.id = keepId)
    AppState.keeps.splice(index, 1)
  }
}

export const keepsService = new KeepsService();