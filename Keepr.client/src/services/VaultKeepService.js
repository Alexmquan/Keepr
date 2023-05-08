import { api } from "./AxiosService.js"

class VaultKeepService {
  async addKeepToVault(vaultKeepData) {
    const res = await api.post("api/vaultKeeps", vaultKeepData)
  }
}

export const vaultKeepService = new VaultKeepService()