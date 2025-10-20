using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.TestimanialDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        private readonly IMapper _mapper;

        public TestimonialManager(ITestimonialDal testimonialDal, IMapper mapper)
        {
            _testimonialDal = testimonialDal;
            _mapper = mapper;
        }

        public void TAdd(TestimonialDto dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _testimonialDal.Insert(entity);
        }

        public void TDelete(TestimonialDto dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _testimonialDal.Delete(entity);
        }

        public void TUpdate(TestimonialDto dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _testimonialDal.Update(entity);
        }

        public List<TestimonialDto> TGetList()
        {
            var entities = _testimonialDal.GetList();
            return _mapper.Map<List<TestimonialDto>>(entities);
        }

        public TestimonialDto TGetById(int id)
        {
            var entity = _testimonialDal.GetById(id);
            return _mapper.Map<TestimonialDto>(entity);
        }

    }
}
