import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class VaultKeepService {
  async addKeepToVault(vaultKeepData) {
    const res = await api.post("api/vaultKeeps", vaultKeepData)
    AppState.keepsInVault.push(res.data)
    AppState.vaultKeeps.push(res.data)
  }

  async removeVaultKeep(vaultKeepId) {
    const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
    const index = AppState.keepsInVault.findIndex(vk => vk.vaultKeepId == vaultKeepId)
    AppState.keepsInVault.splice(index, 1)
  }
}

export const vaultKeepService = new VaultKeepService()