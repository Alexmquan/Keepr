import{g as h,A as d,h as x,i as C,V as B,_ as E,o as M,c as f,S as j,E as F,j as L,a as o,b as t,l as k,t as p,F as m,r as g,d as r,w as y,P as v,m as I,e as _,f as s,u as N,p as z,n as D}from"./index.a3ca8da2.js";class R{async getProfile(n){const c=await h.get(`api/profiles/${n}`);d.profile=new x(c.data)}async getKeepsByProfileId(n){const c=await h.get(`api/profiles/${n}/keeps`);d.keeps=c.data.map(e=>new C(e))}async getVaultsByProfileId(n){const c=await h.get(`api/profiles/${n}/vaults`);d.profileVaults=c.data.map(e=>new B(e))}}const w=new R;const q={setup(){const l=N();async function n(){try{const a=l.params.profileId;await w.getProfile(a)}catch(a){v.error(a)}}async function c(){try{const a=l.params.profileId;await w.getKeepsByProfileId(a)}catch(a){I.log(a.message),v.error(a.message)}}async function e(){try{const a=l.params.profileId;await w.getVaultsByProfileId(a)}catch(a){I.log(a.message),v.error(a.message)}}return M(()=>{n(),c(),e()}),{account:f(()=>d.account),profile:f(()=>d.profile),keeps:f(()=>d.keeps),profileVaults:f(()=>d.profileVaults),myVaults:f(()=>d.myVaults)}},components:{SmallModal:j,EditAccountForm:F,VaultCard:L}},u=l=>(z("data-v-fafcf756"),l=l(),D(),l),G={key:0,class:"main-cont container-fluid"},H={class:"image-cont"},J=["src"],O=["src","title"],Q={key:0,class:"d-flex justify-content-end dropdown-center"},T=u(()=>t("i",{class:"mdi mdi-dots-horizontal selectable me-2 dropdown-toggle fs-2","data-bs-toggle":"dropdown",type:"button",title:"edit account options"},null,-1)),U=u(()=>t("ul",{class:"dropdown-menu drop-style"},[t("li",null,[t("a",{class:"dropdown-item",href:"#","data-bs-toggle":"modal","data-bs-target":"#editAccount"},"Edit Account")])],-1)),W=[T,U],X={key:1,class:"text-center profile-info noSelect"},Y={key:2,class:"text-center profile-info noSelect"},Z={class:"page-bottom"},$=u(()=>t("h2",{class:"width-100 j-content mb-3 noSelect"},"Vaults",-1)),ee={key:0,class:"row width-100"},te=["id"],oe={key:1,class:"row width-100"},se=["id"],ae={class:"mt-4"},le=u(()=>t("h2",{class:"width-100 mb-3 j-content noSelect"},"Keeps",-1)),ne={key:0,class:"width-100 mt-4"},ce=u(()=>t("h1",null," Sorry you haven't added any keeps, please go add some.",-1)),ie=[ce],de={key:1,class:"keep-cont"},re=["id"],pe=u(()=>t("div",null,"Edit your Account",-1));function _e(l,n,c,e,a,ue){const V=_("VaultCard"),P=_("KeepCard"),S=_("ActiveKeepCard"),b=_("LargeModal"),A=_("EditAccountForm"),K=_("SmallModal");return s(),o(m,null,[e.profile?(s(),o("div",G,[t("div",H,[t("img",{class:"cover-img rounded",src:e.profile.coverImg,alt:"",title:"profile cover image"},null,8,J),t("img",{class:"profile-img elevation-4",src:e.profile.picture,alt:"",title:e.profile.name},null,8,O)]),e.account.id==e.profile.id?(s(),o("div",Q,W)):k("",!0),e.account.id!=e.profile.id?(s(),o("div",X,[t("h2",null,p(e.profile.name),1),t("h6",null,p(e.profileVaults.length)+" Vaults | "+p(e.keeps.length)+" Keeps",1)])):(s(),o("div",Y,[t("h2",null,p(e.profile.name),1),t("h6",null,p(e.myVaults.length)+" Vaults | "+p(e.keeps.length)+" Keeps",1)]))])):k("",!0),t("section",Z,[t("div",null,[$,e.account.id!=e.profile.id?(s(),o("div",ee,[(s(!0),o(m,null,g(e.profileVaults,i=>(s(),o("div",{class:"col-md-3 col-6 card-style mb-5 rounded d-flex justify-content-center",id:i.id},[r(V,{vault:i},null,8,["vault"])],8,te))),256))])):(s(),o("div",oe,[(s(!0),o(m,null,g(e.myVaults,i=>(s(),o("div",{class:"col-md-3 col-6 card-style mb-5 rounded d-flex justify-content-center",id:i.id},[r(V,{vault:i},null,8,["vault"])],8,se))),256))]))]),t("div",ae,[le,e.keeps==0?(s(),o("div",ne,ie)):(s(),o("div",de,[(s(!0),o(m,null,g(e.keeps,i=>(s(),o("div",{class:"card card-style mb-3 rounded",id:i.id},[r(P,{keep:i},null,8,["keep"])],8,re))),256))]))])]),r(b,{id:"keepModal"},{body:y(()=>[r(S)]),_:1}),r(K,{id:"editAccount"},{header:y(()=>[pe]),body:y(()=>[r(A)]),_:1})],64)}const me=E(q,[["render",_e],["__scopeId","data-v-fafcf756"]]);export{me as default};
