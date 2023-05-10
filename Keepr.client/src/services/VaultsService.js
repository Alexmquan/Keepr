import { AppState } from "../AppState.js"
import { KeepInVault } from "../models/KeepInVault.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultsService {
  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    logger.log('[New Vault]', res.data)
    AppState.profileVaults.push(new Vault(res.data))
  }

  async setActiveVault(vaultId) {

    const activeVault = AppState.profileVaults.find(v => v.id == vaultId)
    AppState.activeVault = activeVault
  }

  async getVaultById(vaultId) {
    const res = await api.get("api/vaults/" + vaultId)
    AppState.activeVault = new Vault(res.data)
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log("vaultKeep Data", res.data)
    AppState.keepsInVault = res.data.map(k => new KeepInVault(k))
  }

  async editVault(vaultData, vaultId) {
    const res = await api.put(`api/vaults/${vaultId}`, vaultData)
    AppState.activeVault = new Vault(res.data)
  }

  async deleteVault(vaultId) {
    logger.log("test,test, test")
    const res = await api.delete(`api/vaults/${vaultId}`)
    const index = AppState.myVaults.findIndex(v => vaultId == v.id)
    AppState.myVaults.splice(index, 1)
    AppState.activeVault = null
  }


}

export const vaultsService = new VaultsService()