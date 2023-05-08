import { AppState } from "../AppState.js"
import { KeepInVault } from "../models/KeepInVault.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultsService {
  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    logger.log('[New Vault]', res.data)
    AppState.myVaults.push(new Vault(res.data))
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


}

export const vaultsService = new VaultsService()