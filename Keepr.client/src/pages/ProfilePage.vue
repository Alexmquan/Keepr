<template>
  <div class="main-cont container-fluid" v-if="profile">
    <div class="image-cont">
      <img class="cover-img rounded" :src="profile.coverImg" alt="" title="profile cover image">
      <img class="profile-img elevation-4" :src="profile.picture" alt="" :title="profile.name">
    </div>
    <div v-if="account.id == profile.id" class="d-flex justify-content-end dropdown-center">

      <i class="mdi mdi-dots-horizontal selectable me-2 dropdown-toggle fs-2" data-bs-toggle="dropdown" type="button"
        title="edit account options"></i>

      <ul class="dropdown-menu drop-style">
        <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#editAccount">Edit Account</a></li>
      </ul>
    </div>
    <div class="text-center profile-info" v-if="account.id != profile.id">
      <h2>{{ profile.name }}</h2>
      <h6>{{ profileVaults.length }} Vaults | {{ keeps.length }} Keeps</h6>
    </div>
    <div class="text-center profile-info" v-else>
      <h2>{{ profile.name }}</h2>
      <h6>{{ myVaults.length }} Vaults | {{ keeps.length }} Keeps</h6>
    </div>

    <!-- SECTION  VAULTS-->
  </div>
  <section class="page-bottom">

    <div>
      <h2 class="width-100 j-content mb-3">Vaults</h2>

      <div class="row width-100" v-if="account.id != profile.id">
        <div class="col-md-3 col-6 card-style mb-5 rounded d-flex justify-content-center" v-for="v in profileVaults"
          :id="v.id">
          <VaultCard :vault="v" />
        </div>
      </div>

      <div class="row width-100" v-else>
        <div class="col-md-3 col-6 card-style mb-5 rounded d-flex justify-content-center" v-for="v in myVaults"
          :id="v.id">
          <VaultCard :vault="v" />
        </div>
      </div>

    </div>

    <!-- SECTION Keeps -->
    <div class="mt-4 ">
      <h2 class="width-100 mb-3 j-content">Keeps</h2>
      <div class="keep-cont">
        <div class="card card-style mb-3 rounded " v-for="k in keeps" :id="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </section>

  <LargeModal id="keepModal">
    <!-- <template #header>
      <div>Edit your Account</div>
    </template> -->
    <template #body>
      <ActiveKeepCard />
    </template>
  </LargeModal>


  <SmallModal id="editAccount">
    <template #header>
      <div>Edit your Account</div>
    </template>
    <template #body>
      <EditAccountForm />
    </template>
  </SmallModal>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from "../services/AccountService.js"
import Pop from "../utils/Pop.js"
import { useRoute } from "vue-router"
import { profilesService } from "../services/ProfilesService.js"
import SmallModal from "../components/SmallModal.vue"
import EditAccountForm from "../components/EditAccountForm.vue"
import VaultCard from "../components/VaultCard.vue"
import { logger } from "../utils/Logger.js"


export default {
  setup() {
    const route = useRoute();
    async function getProfile() {
      try {
        const profileId = route.params.profileId;
        await profilesService.getProfile(profileId);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getKeepsByProfileId() {
      try {
        const profileId = route.params.profileId;
        // logger.log('[Get postby id]', profileId)
        await profilesService.getKeepsByProfileId(profileId);
      }
      catch (error) {
        logger.log(error.message);
        Pop.error(error.message);
      }
    }

    async function getVaultsByProfileId() {
      try {
        const profileId = route.params.profileId;
        // logger.log('[Get postby id]', profileId)
        await profilesService.getVaultsByProfileId(profileId);
      }
      catch (error) {
        logger.log(error.message);
        Pop.error(error.message);
      }
    }
    onMounted(() => {
      getProfile();
      getKeepsByProfileId();
      getVaultsByProfileId();

    });
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      profileVaults: computed(() => AppState.profileVaults),
      myVaults: computed(() => AppState.myVaults)
    };
  },
  components: { SmallModal, EditAccountForm, VaultCard }
}
</script>

<style scoped>
@media screen and (min-width: 768px) {
  .card {
    border: none;
    background: none;
  }

  .card-style {
    transition: all .2s ease-in-out;
  }

  .card-style:hover {
    cursor: pointer;
    transform: scale(1.04);
  }

  .cover-img {
    width: 100%;
    height: 30vh;
    object-fit: cover;
    object-position: center;
    margin-top: 5vh;
    /* position: relative; */
  }

  .width-100 {
    width: 80vw;
    margin: 0px auto;
  }

  .keep-cont {
    width: 80vw;
    margin: 0px auto;
    columns: 4;
    column-gap: 10vh;
  }

  /* .content-cont {
  width: 80vw;
  margin: 0px auto;
  columns: 4;
  column-gap: 10vh;
} */

  .main-cont {
    width: 65vw;
    margin: 0px auto;
  }

  .profile-info {
    margin-top: 9vh;
  }

  .profile-img {
    height: 15vh;
    width: 15vh;
    object-fit: cover;
    object-position: center;
    border-radius: 50%;
    bottom: -8vh;
    left: 28vw;
    position: absolute;
    border: 2px solid white;
  }

  .image-cont {
    position: relative;
    width: 100%;
  }

  .dropdown-border {
    border-bottom: 2px solid rgb(70, 70, 70);
    width: 80%;
    margin: 0 auto;
  }

  .drop-style {
    background-color: #DED6E9;
    border: 1.5px solid black;
  }
}

@media screen and (max-width: 768px) {
  .keep-cont {
    width: 90vw;
    margin: 0px auto;
    columns: 2;
    column-gap: 2vh;
  }

  .j-content {
    display: flex;
    justify-content: center;
  }

  .cover-img {
    width: 100%;
    height: 30vh;
    object-fit: cover;
    object-position: center;
    /* position: relative; */
  }

  .page-bottom {
    margin-bottom: 10vh;
  }

  .width-100 {
    width: 5vw;
    margin: 0px auto;
  }


  /* .content-cont {
  width: 80vw;
  margin: 0px auto;
  columns: 4;
  column-gap: 10vh;
} */

  .main-cont {
    width: 100vw;
    margin: 0px auto;
  }

  .card {
    --bs-card-bg: none !important;
    --bs-card-border-width: 0px;
  }

  .profile-info {
    margin-top: 9vh;
  }

  .profile-img {
    height: 15vh;
    width: 15vh;
    object-fit: cover;
    object-position: center;
    border-radius: 50%;
    bottom: -8vh;
    left: 34vw;
    position: absolute;
    border: 2px solid white;
  }

  .image-cont {
    position: relative;
    width: 100%;
  }

  .dropdown-border {
    border-bottom: 1px solid rgb(70, 70, 70);
    width: 80%;
    margin: 0 auto;
  }

  .drop-style {
    background-color: #DED6E9;
    border: 1.5px solid black;
  }
}
</style>
