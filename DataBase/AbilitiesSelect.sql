USE [Abilities]
GO

SELECT c.company, (s.skill + ' ' + sv.version) as skill, sv.releaseDate
  FROM SkillsVersions as sv
  inner join Skills as s on s.idSkill = sv.idSkill
  inner join Companies as c on c.idCompany = s.idCompany
  inner join Groups as g on g.idGroup = s.idGroup
  order by sv.releaseDate