using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2Api.Dto;
using WebApplication2Api.Models;

namespace WebApplication2Api.Controllers
{
    public class MembersController : ApiController
    {
        private MemberContext1 context;

        //MemberController Constructor
        public MembersController()
        {
            context = new MemberContext1();
        }


        #region--Get all Elemens by using MemberDto---
        //Get All Elements From mapping with memberDTo rather than domain model
        public IEnumerable<MemberDto> GetMembers()
        {
            return context.Member1s.ToList().Select(Mapper.Map<Member1, MemberDto>);
        }
        #endregion


        #region--Get Element by single Id using MemberDto---
        public MemberDto GetMember(int id)
        {
            var member = context.Member1s.SingleOrDefault(c => c.MemId == id);
            if (member == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Member1, MemberDto>(member);

        }
        #endregion



        #region--Get create Method by using IhttpActionResult---
        [HttpPost]
        //  public MemberDto CreateMember(MemberDto memberDto)
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var member = Mapper.Map<MemberDto, Member1>(memberDto);
            context.Member1s.Add(member);
            context.SaveChanges();
            memberDto.MemId = member.MemId;
            return Created(new Uri(Request.RequestUri + "/" + member.MemId), memberDto);
            //      return memberDto();
        }
        #endregion


        #region--Update Method using HttpPut by using MemberDto class---
        [HttpPut]
        public void UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var memberInDb = context.Member1s.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(memberDto, memberInDb);


            /* memberInDb.MemName = member.MemName;
             memberInDb.MemEmail = member.MemEmail;
             memberInDb.MemAddress = member.MemAddress;*/
            context.SaveChanges();
        }
        #endregion

        #region--Delete Element by  Id using MemberDto class---
        [HttpDelete]
        public void DeleteMember(int id)
        {
            var memberInDb = context.Member1s.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Member1s.Remove(memberInDb);
            context.SaveChanges();
        }
        #endregion

    }
}
