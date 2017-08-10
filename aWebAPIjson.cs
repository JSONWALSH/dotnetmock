        //GET json /api/values/getAirports?  all optional params
        [AllowAnonymous, ActionName("getAirports")]
        public IEnumerable<string> getAirports([FromUri] int? pid = 0, [FromUri] string iata = null, [FromUri] string name = null, StringComparison? ignoreCase = null)
        {
            int pageid = pid ?? 0;
            var caseType = (ignoreCase.HasValue && (int)ignoreCase < 6) ? ignoreCase : StringComparison.CurrentCultureIgnoreCase;

            IList<Airport> airports = _repository.Get().DefaultIfEmpty().Where(m => m.Code.StartsWith(iata ?? m.Code, (StringComparison)caseType) 
                                                                                 && m.Name.StartsWith(name ?? m.Name, (StringComparison)caseType)).ToList();

            while (pageid < airports.Count) yield return JsonConvert.SerializeObject(new { Airport = airports[pageid++] });
        }
