<template>
  <div class="main-cont" v-if="profile">
    <div class="image-cont">
      <img class="cover-img mt-5 rounded" :src="profile.coverImg" alt="">
      <img class="profile-img elevation-4" :src="profile.picture" alt="">
    </div>
    <div class="d-flex justify-content-end dropdown-center">

      <i class="mdi mdi-dots-horizontal selectable me-2 dropdown-toggle fs-2" data-bs-toggle="dropdown" type="button"></i>

      <ul class="dropdown-menu drop-style">
        <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#editAccount">Edit Account</a></li>
        <div class="dropdown-border"></div>
        <li><a class="dropdown-item" href="#">Another action</a></li>
      </ul>
    </div>
    <div class="text-center profile-info">
      <h2>{{ profile.name }}</h2>
      <h6>5 Vaults | {{ keeps.length }} Keeps</h6>
    </div>
    <!-- SECTION  VAULTS-->
  </div>
  <section class="content-cont">

    <div>
      <h2 class="width-100 mb-3">Vaults</h2>
      <div>

      </div>
    </div>
    <!-- SECTION Keeps -->
    <div class="mt-4">
      <h2 class="width-100 mb-3">Keeps</h2>
      <div class=" keep-cont">
        <div class="card card-style mb-5 rounded selectable " v-for="k in keeps" :id="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </section>


  <SmallModal id="createVault">
    <template #header>
      <div>Edit your Account</div>
    </template>
    <template #body>
      <CreateVaultForm />
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
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { SmallModal }
}
</script>

<style scoped>
.cover-img {
  width: 100%;
  height: 30vh;
  object-fit: cover;
  object-position: center;
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
  width: 60vw;
  margin: 0px auto;
}

.profile-info {
  margin-top: 6vh;
}

.profile-img {
  height: 15vh;
  width: 15vh;
  border-radius: 50%;
  bottom: -8vh;
  left: 25vw;
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
</style>
