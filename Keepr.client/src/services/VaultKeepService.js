import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class VaultKeepService {
  async addKeepToVault(vaultKeepData) {
    const res = await api.post("api/vaultKeeps", vaultKeepData)
    AppState.keepsInVault.push(res.data)
    AppState.vaultKeeps.push(res.data)
  }
}

export const vaultKeepService = new VaultKeepService()